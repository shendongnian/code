    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    using System.Text;
    
    [DataContract()]
    class POCO
    {
        [DataMember(Name = "new_token")]
        public string NewToken { get; set; }
    
        [DataMember(Name = "expires_in")]
        public string ExpiresIn { get; set; }
    
        [DataMember(Name = "login_type")]
        public string LoginType { get; set; }
    }
    
    class SomeClass
    {
        void DoSomething(string json)
        {
            MemoryStream reader;
            POCO output;
            DataContractJsonSerializer serializer;
    
            reader = new MemoryStream(Encoding.Unicode.GetBytes(json));
            serializer = new DataContractJsonSerializer(typeof(POCO));
            output = serializer.ReadObject(reader) as POCO;
        }
    }
