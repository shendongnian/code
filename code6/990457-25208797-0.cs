    class Student
    {
        string studentname;
        public Student(string studentname) {
            this.studentname = studentname;
        }
        public List<Department> Departments = new List<Department>();
    }
    class Department
    {
        string departmentname;
        public Department(string departmentname) {
            this.departmentname = departmentname;
        }
        public List<Subject> Subjects = new List<Subject>();
    }
    class Subject
    {
        string subjectname;
        public Subject(string subjectname) {
            this.subjectname = subjectname;
        }
    }
