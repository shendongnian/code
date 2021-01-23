    public class MyIndianMobileLibrary:IMobileStore   //(doesn't implement the interface)
        {
             public MyIndianMobileLibrary(IndianMobileLibrary indian){
              _indianMobileLibrary = indian;
             }
             IndianMobileLibrary _indianMobileLibrary;
             List<string> GetMobileDetails()
             {
                 return indian.GetMobileDetails();
             }
    
             int AddMobile(string mobile)
             {
                 return indian.AddMobile(mobile);
             }
         }
    
        public class IndianMobileLibrary  //(doesn't implement the interface)
            {
                 List<string> GetMobileDetails()
                 {
                     return new List<string>();
                 }
        
                 int AddMobile(string mobile)
                 {
                     return 1;
                 }
             }
