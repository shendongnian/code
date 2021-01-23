    public class Result
    {
        public string ParentName { get; set; }
        public string Type { get; set; }
        public List<CustomSubVariant> CustomSubvariantList { get; set; }
    }
    public class CustomSubVariant
    {
        public int SourceId { get; set; }
        public int TargetId { get; set; }
        public string Name { get; set; }
        public decimal DiffPerc { get; set; }
    }
