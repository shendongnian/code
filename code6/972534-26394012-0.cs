        static System.Net.CookieContainer cookieContainer;
        static void Main(string[] args)
        {
      
            AuthenWS.AuthenticationService authService = new AuthenWS.AuthenticationService();
            authService.CookieContainer = new System.Net.CookieContainer();
             
            AuthenWS.Login loginObj = new AuthenWS.Login();
            loginObj.UserName = "xxx";
            loginObj.Password = "yyy*";
            loginObj.DatabaseInstanceId = 1;
            loginObj.DatabaseInstanceIdSpecified = true;
            AuthenWS.LoginResponse loginReturn = authService.Login(loginObj);
            if (loginReturn.Return == true) cookieContainer = authService.CookieContainer;
            else {
                Console.WriteLine ("login failed");
                return;
            }
            ActivityWS.ActivityService acService = new ActivityWS.ActivityService;
            acService.CookieContainer = cookieContainer;
            ActivityWS.Activity [] acts;
            acts = new ActivityWS.Activity[1];
            ActivityWS.Activity activity = null;
            for (int i = 0; i < 10; i++)
           {
            activity = new ActivityWS.Activity();
            activity.ProjectObjectId = iProjectObjectID;
            activity.ProjectObjectIdSpecified = true;
            activity.Id = "P6 Test" + (i + 1);
            activity.Name = "P6 Test" + (i + 1);
            acts[i] = activity;
           }
            
          acService.CreateActivities(acts);    
      }
