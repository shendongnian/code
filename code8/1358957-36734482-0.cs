    public class ComponentTransaction
    {
        public Guid componentrefid { get; set; }
        public string name { get; set; }
        public DateTime startdate { get; set; }
        public Guid Statusinforefid { get; set; }
        public Guid ScriptRefId { get; set; }
    }
    public class Statusinfo
    {
        public Guid refid { get; set; }
    }
    public class Scriptinfo
    {
        public Guid refid { get; set; }
        public Guid CustomerInfoRefId { get; set; }
    }
