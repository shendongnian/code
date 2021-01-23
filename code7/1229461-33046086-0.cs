    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using System;
    using System.Threading;
    
    namespace ConsoleApplication1
    {
        public class Azure
        {
            private string loginpath = "https://login.windows.net/{0}";
            private string apiEndpoint = "https://management.azure.com/";
    
            //Fill these up
            private string webSiteName = "{your webSiteName}";
            private string webSpaceName = "Default-Web-SoutheastAsia"; //Insert your webSpaceName here
            private string tenantId = "{your tenantId}";
            private string clientId = "{your client Id}";
            private string subscriptionId = "{your subscription Id}";
          
            //Not needed to set in console app because a function is called to get the token
            //string token = "";
    
            public void CreateVD(string name)
            {
                try
                {
                    System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(String.Format(@"https://management.azure.com/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Web/sites/{2}/config/web?api-version=2015-08-01",subscriptionId,webSpaceName,webSiteName));
                    request.Headers.Add("x-ms-version", "2013-03-01");
                    request.ContentType = "application/json";
                    var token = GetAuthorizationHeader();
                    request.Headers.Add("Authorization", "Bearer" + " " + token);
    
                    System.Net.WebResponse response = request.GetResponse();
    
                    string data = "";
                    using (System.IO.Stream stream = response.GetResponseStream())
                    {
                        System.IO.StreamReader sr = new System.IO.StreamReader(stream);
                        data = sr.ReadToEnd();
                        sr.Close();
                        stream.Close();
                        Console.WriteLine("data found");
                    }
    
                    if (data == "")
                    {
                        Console.WriteLine("Error in collecting data");
                        return;
                    }
    
                    string path = name, directory = name;
                    data = data.Replace("virtualApplications\":[", "virtualApplications\":[{\"virtualPath\":\"/" + path + "\",\"physicalPath\":\"site\\\\wwwroot\\\\" + directory + "\",\"preloadEnabled\":false,\"virtualDirectories\":null},");
                    request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(String.Format(@"https://management.azure.com/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Web/sites/{2}/config/web?api-version=2015-08-01",subscriptionId,webSpaceName,webSiteName));
                    request.Headers.Add("x-ms-version", "2013-03-01");
                    request.ContentType = "application/json";
                    request.AllowWriteStreamBuffering = false;
                    request.Accept = "Accept=application/json";
                    request.SendChunked = false;
                    request.Headers.Add("Authorization", "Bearer" + " " + token);
                    request.ContentLength = data.Length;
                    request.Method = "PUT";
    
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(request.GetRequestStream());
                    sw.Write(data);
                    sw.Close();
    
                    response = request.GetResponse();
    
                    using (System.IO.Stream stream = response.GetResponseStream())
                    {
                        data = (new System.IO.StreamReader(stream)).ReadToEnd();
                        Console.WriteLine("DONE");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }
    
            private string GetAuthorizationHeader()
            {
                AuthenticationResult result = null;
    
                var context = new AuthenticationContext(string.Format(loginpath, tenantId));
    
                var thread = new Thread(() =>
                {
                    result = context.AcquireToken(apiEndpoint, clientId, new Uri(redirectUri));
                });
    
                thread.SetApartmentState(ApartmentState.STA);
                thread.Name = "AquireTokenThread";
                thread.Start();
                thread.Join();
    
                if (result == null)
                {
                    throw new InvalidOperationException("Failed to obtain the JWT token");
                }
    
                string token = result.AccessToken;
                return token;
            }
        }
    }
