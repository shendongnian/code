    class Person
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int ID { get; set; }
        public String personName { get; set; }
        public int photoId { get; set; }
    }
