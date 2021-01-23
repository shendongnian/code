    public partial class Class1
    {
        public int Id { get; set; }
        public int Class2_Id{ get; set; }
        [ForeignKey("Class2_Id")]
        public Class2 Class2{ get; set; }
    }
