    public class Company{...}
    
    public class Staff{...}
    
    public class ViewModel{
    public Company Company {get;set;}
    public Staff Staff{get;set;}
    }
    
    controller:
    {
    var viewModel = new ViewModel();
    viewModel.Company = db.Companies.FirstOrDefault(x => x.id == companyId);
    viewModel.Staff = db.Staff.Where(x => x.CompanyId == campanyId).ToList() //or whatever your properties are called.
    
    Return View(viewModel);
    }
