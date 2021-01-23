    public class TestModel : Base
    {
        public int Id { get; set; }
        [PickMe]
        public string MyString { get; set; }
        public NestedModel Nested { get; set; }
        public DateTime ClosedAt { get; set; }
    }
 
    public class NestedModel
    {
        public string Deep { get; set; }
    }
