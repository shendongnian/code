    public class AppFlowMetadata : FlowMetadata
        {
            //static readonly string server = ConfigurationManager.AppSettings["DatabaseServer"];
            //static readonly string serverUser = ConfigurationManager.AppSettings["DatabaseUser"];
            //static readonly string serverPassword = ConfigurationManager.AppSettings["DatabaseUserPassword"];
            //static readonly string serverDatabase = ConfigurationManager.AppSettings["DatabaseName"];
        ////new FileDataStore("Daimto.GoogleCalendar.Auth.Store")
        ////new FileDataStore("Drive.Api.Auth.Store")
        //static DatabaseDataStore databaseDataStore = new DatabaseDataStore(server, serverUser, serverPassword, serverDatabase);
        private static readonly IAuthorizationCodeFlow flow =
    new ForceOfflineGoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
    {
        ClientSecrets = new ClientSecrets
        {
            ClientId = "yourClientId",
            ClientSecret = "yourClientSecret"
            
        },
        Scopes = new[]
        {
    CalendarService.Scope.Calendar, // Manage your calendars
 	//CalendarService.Scope.CalendarReadonly // View your Calendars
        },
        DataStore = new EFDataStore(),
    });
        public override string GetUserId(Controller controller)
        {
            // In this sample we use the session to store the user identifiers.
            // That's not the best practice, because you should have a logic to identify
            // a user. You might want to use "OpenID Connect".
            // You can read more about the protocol in the following link:
            // https://developers.google.com/accounts/docs/OAuth2Login.
            //var user = controller.Session["user"];
            //if (user == null)
            //{
            //    user = Guid.NewGuid();
            //    controller.Session["user"] = user;
            //}
            //return user.ToString();
            //var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            //var manager = new UserManager<ApplicationUser>(store);
            //var currentUser = manager.FindById(controller.User.Identity.GetUserId());
            return controller.User.Identity.GetUserId();
        }
        public override IAuthorizationCodeFlow Flow
        {
            get { return flow; }
        }
        public override string AuthCallback
        {
            get { return @"/GoogleApplication/AuthCallback/IndexAsync"; }
        }
    }
