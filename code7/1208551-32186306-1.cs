    class Program
    {
        static void Main(string[] args)
        {
            SchoolDBEntities dataContext = new SchoolDBEntities();
            //Create student object
            Student student1 = new Student();
            student1.StudentName = "Student 01";
            //Create course objects
            Cours mathCourse = new Cours();
            mathCourse.CourseName = "Math";
            Cours scienceCourse = new Cours();
            scienceCourse.CourseName = "Science";
            //Save courses to student 1
            student1.Courses.Add(mathCourse);
            student1.Courses.Add(scienceCourse);
            //Save related data to database
            //This will automatically populate join table
            //between Students and Courses
            dataContext.Students.Add(student1);
            dataContext.SaveChanges();
        }
    }
