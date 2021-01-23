    public class CustomerContact
    {
        // ...
    }
    public class CompanyAContact : CustomerContact
    {
        // ...
    }
    
    public abstract class Company<T> where T : CustomerContact
    {
        // ...
        public abstract List<T> GetContacts();
    }
    public class CompanyA : Company<CompanyAContact>
    {
        private List<CompanyAContact> _contacts; 
        // ...
        public override List<CompanyAContact> GetContacts()
        {
            return _contacts;
        }
    }
