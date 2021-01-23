    class Constants
    {
        /// <summary>
        /// The final segment of this URL is an allowed tenant. We set this
        /// at portal.azure.com by going to the Gateway for our application 
        /// and choosing Settings > Identity > Azure Active Directory > Allowed Tenants. 
        /// My tenant is bigfontoutlook.onmicrosoft.com        
        /// </summary>
        public const string AUTHORITY =
            "https://login.microsoftonline.com/bigfontoutlook.onmicrosoft.com/";
        /// <summary>
        /// 
        /// </summary>
        public const string CLIENT_ID = "0d7dce06-c3e3-441f-89a7-f828e210ff6d";
        /// <summary>
        /// 
        /// </summary>
        public const string CLIENT_SECRET =
            "AtRMr+Rijrgod4b9Q34i/UILldyJ2VO6n2jswkcVNDs=";
        /// <summary>
        /// 
        /// </summary>
        public const string GATEWAY_URL =
            "https://mvp201514929cfc350148cfa5c9b24a7daaf694.azurewebsites.net/";
        /// <summary>
        /// 
        /// </summary>
        public const string API_ID_URL = GATEWAY_URL + "login/aad";
    }
