    public class ContentViewModel
    {
        public Guid Id { get; set; }
        public int TypeId { get; set; }
        public int FormId { get; set; }
        public DynamicComplexObject ExtraData { get; set; }
    }
    
    public class DynamicComplexObject
    {
        public dynamic Details { get; set; }
    }
