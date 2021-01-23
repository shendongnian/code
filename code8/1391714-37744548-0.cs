    class Base
    {
        [Key]
        public int ID;
        public string Name;
        public string Gender;
        public string Comment;
    }
    [Table("T1")]
    class TableOneEntity : Base
    {
    }
    [Table("T2")]
    class TableTwoEntity : Base
    {
        // extra columns from T2
        public string Country;
        public string City;
    }
    [Table("V1")] // which is a view containing columns from Base, T1 and T2.
    class CompositeEntity : Base
    {
        // extra columns from T1
        .....
        // extra columns from T2
        public string Country;
        public string City;
    }
