    [ActiveRecord("Student")]
    public class Student : ActiveRecordBase<Student>
    {
        [PrimaryKey]
        public virtual int Id { get; set; }
    
        [Property]
        public virtual string Name { get; set; }
    
        [Property]
        public virtual string Grade { get; set; }
    }       
