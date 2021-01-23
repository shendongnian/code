    public class StudentEnrollment
    {
    	private readonly IStudentRepository _studentRepository;
    	
    	// Inject the contract here
    	public StudentEnrollment(IStudentRepository studentRepository)
    	{
    		_studentRepository = studentRepository;
    	}
    	
    	
    	public IEnumerable<Student> GetStudentsForClass(StudentClass studentClass)
    	{
    		return _studentRepository.GetStudents().Where(student => student.class == studentClass);
    	}
    }
