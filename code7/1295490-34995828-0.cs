    static void Main( string[] args )
        {
          Backendless.InitApp( APP_ID, SECRET_KEY, VERSION_ID );
          BackendlessUser loggedInUser = Backendless.UserService.Login( USER_NAME, PASS_WORD );
    
          System.Console.WriteLine( "logged in user - " + loggedInUser.Email );
        }
