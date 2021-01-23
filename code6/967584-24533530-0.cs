    using System.Web.Script.Serialization;
    
    public partial class ResidentialBuilding
    {
        public ResidentialBuilding()
        {
            this.ResidentialDatas = new HashSet<ResidentialData>();
        }
    
        public int Id { get; set; }
        public string type { get; set; }
        public short stories { get; set; }
        public int size { get; set; }
        public string age { get; set; }
        public string orientation { get; set; }
        public string shape { get; set; }
        public int floorht { get; set; }
        public string foundation { get; set; }
        public int windowpercent { get; set; }
        public string heating { get; set; }
        public string cooling { get; set; }
    
        [ScriptIgnoreAttribute]
        public virtual ICollection<ResidentialData> ResidentialDatas { get; set; }
    }
