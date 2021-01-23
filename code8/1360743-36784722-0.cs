    class student
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        [ForeignKey(...)]
        public virtual school School { get; set; }
    }
    
    class school
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual List<student> Students {get; set; }
    }
    
    student student1 = new student();
