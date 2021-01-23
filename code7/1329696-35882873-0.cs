    public override void OnBackPressed(){
     //by this way.. user want be able to hit the back button 
     // unless user is logged in
         if (user.IsLoggedIn()){
             base.OnBackPressed();
          }
    }
