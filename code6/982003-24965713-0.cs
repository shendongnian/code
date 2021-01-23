    public class MyContext : DataContext
    {
        public Table<Student> Students { get { return GetTable<Student>(); } }
        public Table<StudentInfo> StudentInfo { get { return GetTable<StudentInfo>(); } }
        public MyContext(string ConnString) : base(ConnString) {}
    }
    [Table(Name = "dbo.Students")]
    public class Student
    {
        [Column(IsPrimary = true, Name = "StudentId", IsDbGenerated = true, DbType = "int Not Null IDENTITY")]
        public int StudentId { get; set; }
        [Column(Name = "Name")]
        public string Name { get; set; }
    }
    [Table(Name = "dbo.StudentInfo")]
    public class StudentInfo
    {
        [Column(IsPrimary = true, Name = "StudentInfoId", IsDbGenerated = true, DbType = "int Not Null IDENTITY")]
        public int StudentInfoId { get; set; }
        [Column(Name = "StudentId")]
        public int StudentId { get; set; }  // FK
        [Column(Name = "Address")]
        public string Address{ get; set; }
    }
    // a method somewhere
    public void StudentLookup(string name)
    {
        var MyContext context = new MyContext(connString);
        var student = context.Students.Single(x => x.Name == name)
        var StudentInfo = context.StudentInfo.Where(x => x.StudentId == student.StudentId);
    }
