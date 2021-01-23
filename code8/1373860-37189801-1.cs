    public class MyClass
    {
        private FixedString companyNumber = new FixedString(5);
    
        public string CompanyNumber
        {
            get{ return companyNumber.Value; }
            set{ companyNumber.Value = value; }
        }
    }
