    public class Course
    {
        string courseCode {get; private set;}
        string courseTitle {get; private set;}
        Professor teacher {get; private set;}
    
        public Course(string courseCode, string courseTitle, Professor teacher)
        {
            this.courseCode = courseCode;
            this.courseTitle = courseTitle;
            //notice argument teacher is only used for cloning
            this.teacher = new Professor
            {
              id= teacher.id,
              firstName = teacher.firstName,
              lastName = teacher.lastName,
            }    
        }
    }
