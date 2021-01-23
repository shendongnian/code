    public class MyPoco
    {
        public int Id { get; set; }
        [NotMapped]
        public string Name { get; set; }
        public int SomeSpecialId { get; set; }
    }
