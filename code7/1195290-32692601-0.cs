    [DataContract]
    public class EndSessionRequestMany
    {
        [DataMember]
        public string acc { get; set; }
        [DataMember]
        public List<PageDetails> counters { get; set; }
    }
    public JsonResponse EndSession(string user_token, string term, string brandname)
    {
        string JSONstring = OperationContext.Current.RequestContext.RequestMessage.ToString();
        
        XmlReader reader = XmlReader.Create(new StringReader(JSONstring));
        EndSessionRequestMany objEndSessionMany = (EndSessionRequestMany)new DataContractJsonSerializer(typeof(EndSessionRequestMany)).ReadObject(reader);
    }
