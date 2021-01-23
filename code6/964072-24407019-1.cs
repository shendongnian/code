    public class Student
    {
        int NoOfParties;
        int NoOfHangOvers;
    }
    
    public interface IRepo<T>
    {
        IEnumerable<T> GetAll();
        T GetByID();
    }
    
    public interface IRepoCreate<T>
    {
        Int32 Create();
    }
    
    public interface IRepoDelete<T>
    {
        void Delete();
    }
    
    public interface IStudentRepo : IRepo<Student>, IRepoCreate<Student>, IRepoDelete<Student>
    {
        IEnumerable<Student> GetAll();
        Student GetByID();
        int Create();
        void Delete();
        Student GetByParty();
    }
    
    public class MSSQLStudentRepo : IStudentRepo
    {
        public IEnumerable<Student> GetAll() { \\stuff }
        public Student GetByID() { \\stuff }
        public int Create() { \\stuff }
        public void Delete() { \\stuff }
        public Student GetByParty() { \\stuff }
    } 
    
    public class MySQLStudentRepo : IStudentRepo
    {
        public IEnumerable<Student> GetAll() { \\stuff }
        public Student GetByID() { \\stuff }
        public int Create() { \\stuff }
        public void Delete() { \\stuff }
        public Student GetByParty() { \\stuff }
    }
    public void ImplementationExample()
    {
        IStudentRepo Repo = new MSSQLStudentRepo();
        var Bob = Repo.GetByParty();
    }   
