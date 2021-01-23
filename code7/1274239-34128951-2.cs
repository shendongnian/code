    public class DesignEntity
    {
        public string DesignName { get; set; }
        public string DesignID { get; set; }
        /// new field
        public DesignDetailsObject DesignDetails { get; set; }
        [ScriptIgnore]
        public string designDetails { get; set; }
    }
