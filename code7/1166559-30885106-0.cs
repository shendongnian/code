    [TableName("Projects")]
    [PrimaryKey("Id", autoIncrement = true)] // This was missing
    public class Project
    {
        [PrimaryKeyColumn(AutoIncrement=true)]
        public int Id { get; set; }
    
        [Required]
        public string Name { get; set; }
    }
    [TableName("Students")]
    [PrimaryKey("Id", autoIncrement = true)] // this was missing
    //, but only affected class with foreign key
    public class Student
    {
        [PrimaryKeyColumn(AutoIncrement=true)]
        public int Id { get; set; }
    
        [Required]
        public string Name { get; set; }
    
        [ForeignKey(typeof(Project))]
        public int ProjectId { get; set; }
    }
