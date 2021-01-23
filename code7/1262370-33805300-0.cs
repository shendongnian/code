    [Table("People")]
    public class Person
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar")]
        public string Name { get; set; }
        [Column(TypeName="date")]
        public DateTime DOB { get; set; }
    }
