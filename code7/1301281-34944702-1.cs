       public class StudentController : Controller
       {
          private IStudentRepository studentRepository;
    
          public StudentController(IStudentRepository studentRepository)
          {
            this.studentRepository = studentRepository;
          }
  
