    class RegistrationViewModel
    {
        SiteDataModel db = new SiteDataModel();
 
        public AddUserAndAddress(Web_User_Address address, Web_User user){
           //Note: address has a userId 
           var user = db.Web_User.First(a => a.Name== user.Name && /*etc*/ );
           if(user != null){
           // User already exists. Do something about that here
           } 
           db.Web_User_Address.Add(address);
           db.Web_User.Add(user);
           db.SaveChanges();
        }  
    }
