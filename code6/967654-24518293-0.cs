    namespace MyIndianMobileLibrary 
    {
        public class MyIndianMobileLibraryImpl : IMobileStore
        {
            List<string> GetMobileDetails()
            {
                 return new IndianMobileLibrary.GetMobileDetails();
            }
    
            int AddMobile(string mobile)
            {
                 return 1;
            }
    }
