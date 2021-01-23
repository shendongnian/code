    namespace myapp
    {
        /// <summary>
        /// Provides application-specific behavior to supplement the default Application class.
        /// </summary>
        sealed partial class App : Application
        {
    
            // This MobileServiceClient has been configured to communicate with the Azure Mobile App.
            // You're all set to start working with your Mobile App!
            public static MobileServiceClient MobileService = new MobileServiceClient("https://my-apservice.azurewebsites.net");
