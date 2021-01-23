    public class StudentRepository : DbContext, IStudentRepository
    {
    	private DbSet<Student> Students;
    	
    	public IEnumerable<Student> GetStudents()
    	{
    		return Students;
    	}
    }
