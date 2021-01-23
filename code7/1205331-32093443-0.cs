    public class Foo: EntityData
    {
        public string CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public string Name { get; set; }
    }
    public class Category : EntityData
    {
        public string Name { get; set; }
    }
