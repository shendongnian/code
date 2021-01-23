    public class TeacherInfo
    {
        //Properties for store info from database
    }
    public class Teacher : BaseClass<TeacherInfo>
    {
         public Teacher ()
             : BaseClass()
         {
             query = "whatever you want here"
         }             
    }
    public class StudentInfo
    {
        //Properties for store info from database
    }
    public class Student : BaseClass<StudentInfo>
    {
         public Student ()
             : BaseClass()
         {
             query = "whatever you want here";
         }
    
    }
