    public class MyIndianMobileLibrary:IMobileStore
        {
             public MyIndianMobileLibrary(IndianMobileLibrary indian){
              _indianMobileLibrary = indian;
             }
             IndianMobileLibrary _indianMobileLibrary;
             public List<string> GetMobileDetails()
             {
                 return indian.GetMobileDetails();
             }
    
             public int AddMobile(string mobile)
             {
                 return indian.AddMobile(mobile);
             }
         }
    
        public class IndianMobileLibrary  //(doesn't implement the interface)
            {
                 public List<string> GetMobileDetails()
                 {
                     return new List<string>();
                 }
        
                 public int AddMobile(string mobile)
                 {
                     return 1;
                 }
             }
