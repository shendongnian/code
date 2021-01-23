    [DataContract]
    public class JsonResponse
    { 
        [datamember]
        public string kind;
        [datamember]
        public string selflink;
        [datamember]
        public Entry entries;
    }
    [DataContract]
    public class Entry
    { 
        [datamember]
        public nestedstat nestedstats;
    }
