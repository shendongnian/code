    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Services;
    using System;
    using System.Linq;
    using Google.Apis.Admin.Directory.directory_v1;
    using System.Security.Cryptography.X509Certificates;
    
    namespace GoogleApis
    {
    
        /// <summary>
        /// This sample demonstrates the simplest use case for a Service Account service.
        /// The certificate needs to be downloaded from the Google Developers Console
        /// <see cref="https://console.developers.google.com/">
        ///   "Create another client ID..." -> "Service Account" -> Download the certificate,
        ///   rename it as "key.p12" and add it to the project. Don't forget to change the Build action
        ///   to "Content" and the Copy to Output Directory to "Copy if newer".
        /// </summary>
        public class Program
        {
            public static void Main(string[] args)
            {
                //Service account Email 
                //NOTE: This is the account for the Service Client
                string serviceAccountEmail = "service.account@appspot.gserviceaccount.com";
    
                //Path to Downloaded Key
                var path = @"Path\To\key.p12";
    
                //Generate a Certificate using the Key downloaded from the Api Console
                var certificate = new X509Certificate2(path, "notasecret", X509KeyStorageFlags.Exportable);
    
                //Create the Credential
                ServiceAccountCredential serviceCredential = new ServiceAccountCredential(
                   new ServiceAccountCredential.Initializer(serviceAccountEmail)
                   {
                       //Define the Scopes You want the credential to Access
                       Scopes = new[]
                       {
                           DirectoryService.Scope.AdminDirectoryUser,
                       },
                       //Specify the User that this service Credential is Impersonating. Typically your Google Apps Admin Account
                       User = "admin@domain.com"
                   }.FromCertificate(certificate));
    
                //Instantiate the Service (Could be any of the Google Api Services)
                var service = new DirectoryService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = serviceCredential,
                });
    
                // Define parameters of request.
                UsersResource.ListRequest request = service.Users.List();
                //Set the Domain of the Request
                request.Domain = "domain.com";
    
                // List users.
                var users = request.Execute().UsersValue;
                users.Select(u => u.PrimaryEmail).ToList().ForEach(Console.WriteLine);
                Console.ReadKey();
            }
        }
    }
