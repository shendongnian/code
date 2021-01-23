    [JsonObject(MemberSerialization.OptIn)]
    public class LinkListOfUserGroup
    {
        [JsonProperty]
        public List<NameIDItem> NewItems { get; set; }
        [JsonProperty]
        public List<NameIDItem> RemovedItems { get; set; }
        [JsonProperty]
        public bool TrackChanges { get; set; }
        [JsonProperty]
        public List<NameIDItem> Items { get; set; }
    }
