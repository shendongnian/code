    Public class School
    {
        [Key]
        public Guid SchoolId { get; set; }
        public string Name { get; set; }
        public string Branch { get; set; }
        public int NumberOfStudents  { get; set; }
    }
