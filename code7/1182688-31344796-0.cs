    public class MyController : ApiController 
    {
        private ICompanyRepository companyRepository;
        private IPersonRepository personRepository;
    
        public MyController ()
        {
            companyRepository = new CompanyRepository();
            personRepository = new PersonRepository();
        }
    
        public MyController (ICompanyRepository CompanyRepository, IPersonRepository PersonRepository )
        {
            companyRepository = CompanyRepository;
            personRepository = PersonRepository;
        }
    }
