    void Main
    {    
      School school = new School();
      school.Add("Harry", "Quiddich");
      school.Add("Ron", "Quiddich");
      school.Add("Neville", "Herbology");
      school.Add("Hermione", "Herbology");
      school.Add("Hermione", "Divination");
      var orderedTeachers =
           school.Teachers.OrderBy(t => t.TeacherName)
                .SelectMany(
                    x => x.Subjects.OrderBy(s => s).Select(s => new {Teacher = x.TeacherName, Subject = s}));
    }
    internal class School
    {
        internal List<string> TaughtSubjects { get; } = new List<string>();
        internal List<Teacher> Teachers { get; } = new List<Teacher>();
        internal void Add(string teacherName, string subjectName)
        {
            // check to see if we have alreay defined this subject
            var subject = TaughtSubjects.SingleOrDefault(s => s == subjectName);
            // else create the subject and add to the school curriculum
            if (subject == null)
            {
                subject = subjectName;
                TaughtSubjects.Add(subject);
            }
            // check to see if the teacher is already on the school payroll
            var teacher = Teachers.SingleOrDefault(s => s.TeacherName == teacherName);
            // if not then add him or her
            if (teacher == null)
            {
                teacher = new Teacher(teacherName);
                Teachers.Add(teacher);
            }
            // check that the teacher isn't already down for teaching that subject before making the link
            if (!teacher.Subjects.Contains(subject))
                teacher.Subjects.Add(subject);
        }
    }
    internal class Teacher
    {
        internal Teacher(string teacherName)
        {
            TeacherName = teacherName;
        }
        internal string TeacherName { get; }
        public List<string> Subjects { get; } = new List<string>();
    }
