    void Main()
    {
    	Student s = new Student() {
    	  Name = "fred",
    	  Age = 10
    	  };
    	List<Student> _s = new List<Student>();
    	_s.Add(s);
    	
    	Record r = new Record();
    	r.Students = _s;  //You'll get a message here
    	r.Students.Add(s);  //No message here
    }
    
    // Define other methods and classes here
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    
    public class Record
    {
        List<Student> _students = new List<Student>();
    
        public List<Student> Students 
        {
            get
            {
                return _students;
            }
            set
            {
                // track changes here...
                MessageBox.Show("value set!"); 
                _students = value;
            }
        }
    }
