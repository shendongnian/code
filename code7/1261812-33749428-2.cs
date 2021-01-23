    using CbilFileReader.CibilWcfService;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
    
               
                CIBIL obj = new CIBIL();
                CibilEnquiry CibilEnquiryEnq = new CibilEnquiry();
                TUEF objtuef = new TUEF();
                objtuef.Version = "123";
                CibilEnquiryEnq.Tuef = objtuef;
                string res = obj.GenerateEnquiry(CibilEnquiryEnq);
            }
        }
    }
