    var context = new StreamingContext(StreamingContextStates.Persistence);
    var s = new System.Runtime.Serialization.NetDataContractSerializer();
    
    var sb = new StringBuilder();
    
    using (var writer = new XmlTextWriter(new StringWriter(sb)))
    {      
        s.WriteObject(writer, new Test() { SomeFunc = (int i) => "Hi".Dump().Length });
    }
    sb.ToString().Dump();
    [DataContract]
    class Test
    {
        [DataMember]
        public Func<int, int> SomeFunc;
    }
