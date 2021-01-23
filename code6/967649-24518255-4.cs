         public class MyIndianMobileLibrary:IndianMobileLibrary,IMobileStore 
        {
             public MyIndianMobileLibrary(){
             }
             public List<string> GetMobileDetails()
             {
                 return base.GetMobileDetails();
             }
    
             public int AddMobile(string mobile)
             {
                 return base.AddMobile(mobile);
             }
         }
