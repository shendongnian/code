    public class Student
    {
            public virtual int      StudentID { get; set; }
            public virtual string   Name1 { get; set; }
            public virtual string   Name2 { get; set; }
            public virtual List<Class> ClassList  { get; set; }
    }
    
    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            Id(x => x.StudentID ).Column("student_id");
            Map(x => x.Name1 ).Column("name_1");
            Map(x => x.Name1 ).Column("name_2");
            HasMany(x => x.Class).KeyColumn("ClassId")
            Table("student");
        }
    }
    
    public class Class
    {
            public virtual int      ClassID { get; set; }
            public virtual string   Name { get; set; }
            public virtual IList<Student> StudentList { get; set; }
            public virtual School School  { get; set; }
    }
    
    public class ClassMap : ClassMap<Class>
    {
        public ClassMap ()
        {
            Id(x => x.ClassID ).Column("class_id");
            Map(x => x.Name ).Column("name");
            HasMany(x => x.Student).KeyColumn("StudentId")
            References(x => x.School)
            Table("class");
        }
    }
    
    public class School
    {
        public virtual int      SchoolID { get; set; }
        public virtual string   Name { get; set; }
        public virtual IList<Class> ClassList { get; set; }
    }
    
    public class SchoolMap : ClassMap<School>
    {
        public SchoolMap ()
        {
            Id(x => x.SchoolID ).Column("SchoolId");
            Map(x => x.Name ).Column("name");
            HasMany(x => x.ClassList).KeyColumn("ClassId")
            Table("school");
        }
    }
