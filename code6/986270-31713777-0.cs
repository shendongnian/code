    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Reflection;
    using System.Security;
    using System.Threading.Tasks;
    using LyncConnectivityAnalyzer.Logging;
    using Microsoft.LyncServer.WebServices;
    using Microsoft.Utilities.Credentials;
    
    namespace SM.CoolStuff
    {
        /// <summary>
        /// Helper class for performing auto-discovery and authentication to the Lync/Skype UCWA sevice on Office365
        /// </summary>
        public class SkypeHelper
        {
            private string _webTicket;
            private string _ucwaRootPath;
            private readonly ILyncLogging _logger = new Logger();
    
            /// <summary>
            /// Initializes the connection/authentication/etc.  Once this method completes, <see cref="_webTicket"/> and <see cref="_ucwaRootPath"/> will
            /// be populated.
            /// </summary>
            private async Task Initialize(string userName, SecureString password)
            {
                //Setup the credential
                var userCreds = new Credentials
                {
                    UPN = userName,
                    SecurePassword = password,
                    credsType = CredInputType.CredDialog,
                    URI = userName
                };
    
                //Perform auto-discovery to get the UCWA path
                //We'll just always allow redirects
                ValidateRedirectRequestDelegate alwaysAllowRedirect = (logger, url, destinationUrl) => true;
                var adm = new AutoDiscoverManager(_logger, "http://lyncdiscover." + userCreds.Domain, userCreds.URI, userCreds, alwaysAllowRedirect);
                await adm.StartDiscoveryJourney();
    
                //Save the path
                _ucwaRootPath = adm.GetAutoDiscoverAddress().ExternalUcwa;
    
                //Setup the 'validator' that does all the heavy lifting
                var webServicesValidation = new WebServicesValidation(_logger, _ucwaRootPath, userCreds)
                {
                    HttpRequestBody = ApplicationPostBody,
                    customHeaders = CustomHeaders,
                    getPost = HttpMethod.Post
                };
    
                //Make a first request that should gracefully fail with 'authorization required'
                await webServicesValidation.CheckURL(_ucwaRootPath, false);
    
                //Now authorize the request
                await webServicesValidation.TryURLAuth(_ucwaRootPath);
    
                //Use some ugly reflection to get the ticket value.  There may be a better way but this works
                _webTicket = (string)WebTicketField.GetValue(webServicesValidation);
            }
    
            /// <summary>
            /// Example usage
            /// </summary>
            public async Task DoSomethingOnSkype()
            {
                //If you already have a SecureString, might as well use that.  Otherwise, convert an 'insecure' string to be 'Secure'
                var secureString = new SecureString();
                "TopSecret".ToList().ForEach(secureString.AppendChar);
    
                //Do the initialization
                await Initialize("user@somewhere.com", secureString);
    
                //TODO: Use _webTicket and _host to query something
            }
    
            private static readonly string ApplicationPostBody =
                string.Concat(
                    "<input xmlns=\"http://schemas.microsoft.com/rtc/2012/03/ucwa\"><property name=\"culture\">en-US</property><property name=\"endpointId\">44:D8:84:3C:68:68</property><property name=\"type\">Phone</property><property name=\"userAgent\">",
                    //TODO: Your app name here
                    "LyncConnectivityAnalyzer", "/",
                    //TODO: Your app version here
                    "5.0.8308.582",
                    " (Windows OS 6.0)</property></input>");
    
            private static readonly Dictionary<string, string> CustomHeaders = new Dictionary<string, string>
            {
                {"Accept", "application/vnd.microsoft.com.ucwa+xml"},
                {"Content-Type", "application/vnd.microsoft.com.ucwa+xml"},
                {"X-MS-Namespace", "internal"},
                {"Connection", "keep-alive"},
                {"Proxy-Connection", "keep-alive"}
            };
    
            private static readonly FieldInfo WebTicketField = FindWebTicketField();
    
            private static FieldInfo FindWebTicketField()
            {
                var fieldInfo = typeof(WebServicesValidation).GetField("_webticket", BindingFlags.Instance | BindingFlags.NonPublic);
                if (fieldInfo == null)
                {
                    throw new ApplicationException("Could not find private _webticket field");
                }
                return fieldInfo;
            }
       }
    }
