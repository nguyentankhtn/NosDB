﻿// /*
// * Copyright (c) 2016, Alachisoft. All Rights Reserved.
// *
// * Licensed under the Apache License, Version 2.0 (the "License");
// * you may not use this file except in compliance with the License.
// * You may obtain a copy of the License at
// *
// * http://www.apache.org/licenses/LICENSE-2.0
// *
// * Unless required by applicable law or agreed to in writing, software
// * distributed under the License is distributed on an "AS IS" BASIS,
// * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// * See the License for the specific language governing permissions and
// * limitations under the License.
// */
using Alachisoft.NosDB.Common.Security.Interfaces;
using Alachisoft.NosDB.Common.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alachisoft.NosDB.Common.Security.Server
{
    public class SSPIServerAuthenticationCredential : IServerAuthenticationCredential, ICompactSerializable
    {
        public AuthToken Token { set; get; }

        public ISessionId SessionId { set; get; }

        public bool IsAuthenticated { get; set; }

        public void Deserialize(Serialization.IO.CompactReader reader)
        {
            IsAuthenticated = (bool)reader.ReadObject();
            Token = (AuthToken)reader.ReadObject();
            SessionId = reader.ReadObject() as ISessionId;
        }

        public void Serialize(Serialization.IO.CompactWriter writer)
        {
            writer.WriteObject(IsAuthenticated);
            writer.WriteObject(Token);
            writer.WriteObject(SessionId);
        }
    }
}
