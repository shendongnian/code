    public class StudentsBusinessLogic:IStudentsBusinessLogic
    {
        private IStudentRepository _studentRepository;
        public StudentsBusinessLogic(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
        }
    ...
