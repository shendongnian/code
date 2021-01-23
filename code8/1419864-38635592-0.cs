     [AllowAnonymous]
     public async Task<ViewResult> ClearAlerts(string userId)
     {
          if ( string.IsNullOrEmpty( userId ) )
          {
              return RedirectToAction( "Index","Home" );
          }
          
          var user = await UserManager.FindByIdAsync( userId );
          if( user == null )
          {
              return RedirectToAction("Index","Home");
          }
          // do stuff
     }
