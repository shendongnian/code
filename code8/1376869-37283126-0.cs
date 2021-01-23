    namespace IMDSEbs.Controllers
    {
        public class CompanyController : ApiController
        {
       
            // GET api/values
            public IEnumerable<CompanyName> GetCompanyNames(string query)
            {
                IMDSDataContext dc = new IMDSDataContext();
                List<CompanyName> results = new List<CompanyName>();
                foreach(IMDSEbs.Models.Company comp in dc.Companies)
                {
                    results.Add(new CompanyName()
                    {
                        ID = comp.CompanyID,
                        Name = comp.CompanyName
                    });
                }
    
                return results.Where(m => m.Name.Contains(query)).ToList();
            }
    
    
        }
    }
