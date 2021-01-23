         public class MyIndianMobileLibrary:IndianMobileLibrary,IMobileStore   //(doesn't implement the interface)
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
