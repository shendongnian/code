    public class Name
    {
        public int order { get; set; }
        public string name { get; set; }
        public string registrationDate { get; set; }
        public object endDate { get; set; }
        public object language { get; set; }
    }
    
    public class CompanyForm
    {
        public string type { get; set; }
        public string registrationDate { get; set; }
    }
    
    public class Address
    {
        public string street { get; set; }
        public string postCode { get; set; }
        public int type { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string website { get; set; }
        public object phone { get; set; }
        public object fax { get; set; }
        public string registrationDate { get; set; }
        public object endDate { get; set; }
    }
    
    public class RegisteredOffice
    {
        public string registeredOffice { get; set; }
        public string language { get; set; }
        public string registrationDate { get; set; }
        public object endDate { get; set; }
    }
    
    public class Result
    {
        public string businessId { get; set; }
        public string name { get; set; }
        public string registrationDate { get; set; }
        public string companyForm { get; set; }
        public object detailsUri { get; set; }
        public string bisDetailsUri { get; set; }
        public string language { get; set; }
        public string latestRegistrationDate { get; set; }
        public string checkDate { get; set; }
        public List<Name> names { get; set; }
        public List<object> auxiliaryNames { get; set; }
        public List<CompanyForm> companyForms { get; set; }
        public List<Address> addresses { get; set; }
        public List<object> publicNotices { get; set; }
        public List<RegisteredOffice> registeredOffices { get; set; }
    }
    
    public class RootObject
    {
        public string type { get; set; }
        public string version { get; set; }
        public int totalResults { get; set; }
        public int resultsFrom { get; set; }
        public object previousResultsUri { get; set; }
        public string nextResultsUri { get; set; }
        public object exceptionNoticeUri { get; set; }
        public List<Result> results { get; set; }
    }
