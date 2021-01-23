    private ConcurrentDictionary<int,Student> _students;
    public static IEnumerable<Student> GetStudents()
    {
       return _students.Select(x => x.Value);
    }
    
    public static Student GetStudentByID(int id) 
    {
       Student s;
       if(_students.TryGetValue(id, out s)) return s;
       s = getStudentFromDb(id);
       _students[id] = s;
       return s;
    }
