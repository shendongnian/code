    [DataContract]
    public class JsonResponse
    { 
        [datamember]
        public string kind;
        [datamember]
        public string selflink;
        [datamember]
        public Entry entries; //we nest another object here just as in the json
    }
    [DataContract]
    public class Entry
    { 
        [datamember]
        public nestedstat nestedstats;
    }
