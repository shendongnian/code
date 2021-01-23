    public void Loging(string name, string pass){
      var isAllowed(name, pass); //Check if user exists and if pass is correct
      if(!isAllowed) return; //we return if user is invalid
      var wService = new WindowsService();
      var myUser = new UserWindowViewModel(name){
        //you set all proeperties you need here
      }
      wService.ShowUserWindow(myUser);
    }
 
