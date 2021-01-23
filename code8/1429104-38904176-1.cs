    public partial class CompanyFormsContext : DbContext
    {
        public CompanyFormsContext()
            : base("name=CompanyFormsContext")
        {
        }
    
        public CompanyFormsContext(string connName)
            : base("name=" + connName)
        {
        }
    ...
    }
