    using RestSharp;
    using RestSharp.Deserializers;
    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Program p = new Program();
    
                var project = p.GetProjects();
            }
    
            public class ProjectResult 
            {
                public Project project { get; set; }
            }
        
            public class Project
            {
                public int id { get; set; }
            }
    
            public List<ProjectResult> GetProjects()
            {
                var request = new RestRequest("projects", Method.GET);
                request.RequestFormat = DataFormat.Json;
                return Execute<List<ProjectResult>>(request);
            }
    
            private T Execute<T>(RestRequest request) where T : new()
            {
                var client = new RestClient();
                client.BaseUrl = "http://127.0.0.1:1337/";
                //client.Authenticator = new HttpBasicAuthenticator(_username, _password);
                var response = client.Execute<T>(request);
    
                if (response.ErrorException != null)
                {
                    const string message = "Error retrieving response.  Check inner details for more info.";
                    var exception = new ApplicationException(message, response.ErrorException);
                    throw exception;
                }
                return response.Data;
            }
        }
    }
