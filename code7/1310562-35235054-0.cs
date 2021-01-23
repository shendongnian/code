    [Serializable]
    public class LayoutDetails
    {       
        [OptionalField]
        private int? offset;
        public bool IsRefreshEnabled { get; set; }
    
        public string GridSettings { get; set; }
    
        public List<string> GroupByPropertyNames { get; set; }
        public int? Offset
        {
            get { return offset; }
            set { offset = value; }
        }
    }
