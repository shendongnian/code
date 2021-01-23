    public class RootObject
    {
        public List<BusinessGroup> GetBusinessGroupsRestResult { get; set; }
    }
    
    public class BusinessGroup
    {
        [DeserializeAs(Name = "BgId")]
        public int BusinessGroupId { get; set; }
    
        public int NodeLevel { get; set; }
        public string BusinessDescription { get; set; }
        public string BusinessName { get; set; }
    
        [DeserializeAs(Name = "ParentID")]
        public int ParentId { get; set; }
    
        [DeserializeAs(Name = "nodegroupid")]
        public int NodeGroupId { get; set; }
    
        [DeserializeAs(Name = "nodegroupname")]
        public string NodeGroupName { get; set; }
    
        [DeserializeAs(Name = "nodegroupdesc")]
        public string NodeGroupDesc { get; set; }
    
        [DeserializeAs(Name = "sorkkey")]
        public string SortKey { get; set; }
    
        public int Marked { get; set; }
    }
