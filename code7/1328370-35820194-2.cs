    namespace WebApplication5
    {
        public interface IStudentDataAccess
        {
            string Hello();
        }
    
        public class StudentDataAccess : IStudentDataAccess
        {
            public string Hello()
            {
                return "Hello from Service";
            }
        }
    }
