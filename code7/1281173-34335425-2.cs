    public class AppealProperty
    {
        public string Address { get; set; }
        public int propID { get; set; }
    }
    public class Appeal
    {
        public string ID { get; set; }
        public List<int> comps { get; set; }
        public AppealProperty property { get; set; }
        public string timeDateStamp { get; set; }
        public string userUUID { get; set; }
        public int year { get; set; }
    }
   
    public class FireBase
    {
        public Appeal Appeal { get; set; }
    }
    public class RootObject
    {
        [JsonProperty(PropertyName = " - K5f0ccEKkVkxTAavQKY")]
        public FireBase FireBaseRoot
        {
            get;
            set;
        }
    }
