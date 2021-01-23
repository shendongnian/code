    public class ContentViewModel
    {
        public Guid Id { get; set; }
        public int TypeId { get; set; }
        public int FormId { get; set; }
        public DynamicComplexObject ExtraData { get; set; }
    }
    //You may try to improve the following model and update the custom model binder logic as appropriate.
    public class DynamicComplexObject
    {
        public dynamic Details { get; set; }
    }
