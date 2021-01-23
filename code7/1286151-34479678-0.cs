    using System.Data;
     
    using CMS.Base;
    using CMS.Membership;
    using CMS.DataEngine;
     
    [AuthenticationHandler]
    public partial class CMSModuleLoader
    {
        /// <summary>
        /// Custom attribute class.
        /// </summary>
        private class AuthenticationHandler : CMSLoaderAttribute
        {
            /// <summary>
            /// Called automatically when the application starts
            /// </summary>
            public override void Init()
            {
                // Assigns a handler to the SecurityEvents.Authenticate.Execute event
                // This event occurs when users attempt to log in on the website
                SecurityEvents.Authenticate.Execute += OnAuthentication;
            }
        }
    }
