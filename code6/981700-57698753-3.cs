        public class Service : IService
        {
                [WebInvoke(Method = "POST", UriTemplate = "/json/MyMethod", RequestFormat = WebMessageFormat.Json,  ResponseFormat = WebMessageFormat.Json)]
                public OutputData MyMethod(InputData inputData)
                {
                   //Implementation
                   return new OutputData();
        
                }
        }
