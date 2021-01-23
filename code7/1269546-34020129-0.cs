    public class StudentServiceProxy : ClientBase<IStudentService>, IStudentService
     {
         public string GetStudentInfo(int studentId)
         {
               return base.Channel.GetStudentInfo(studentId);
         }
     }
