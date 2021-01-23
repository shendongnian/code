    public partial class MyObject
    {
        [Key]
        public int Id { get; set; }
        public string Desciption { get; set; }
        public virtual List<MyObject> ParentObjects { get; set; }
        public virtual List<MyObject> ChildObjects { get; set; }
    }
