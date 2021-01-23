    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using System.Net.Http;
    using System.Net.Http.Headers;
    
    namespace AssociateWorkItemToBuild
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(
                         ASCIIEncoding.ASCII.GetBytes(
                            string.Format("{0}:{1}", "username", "password"))));
    
                    string Url = "https://xxxxxx.visualstudio.com/_apis/wit/workitems/149?api-version=1.0";
                    StringBuilder body = new StringBuilder();
                    body.Append("[");
                    body.Append("{");
                    body.Append("\"op\":\"add\",");
                    body.Append(" \"path\":\"/relations/-\",");
                    body.Append("\"value\":");
                    body.Append("{");
                    body.Append("\"rel\": \"ArtifactLink\",");
                    body.Append("\"url\": \"vstfs:///Build/Build/12596\"");
                    body.Append("}");
                    body.Append("}");
                    body.Append("]");
    
                    var method = new HttpMethod("PATCH");
                    var request = new HttpRequestMessage(method, Url)
                    {
                        Content = new StringContent(body.ToString(), Encoding.UTF8,
                                        "application/json-patch+json")
                    };
    
                    using (HttpResponseMessage response = client.SendAsync(request).Result)
                    {
                        response.EnsureSuccessStatusCode();
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                    }
                }
            }
        }
    }
