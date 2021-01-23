    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Net.Http;
    using System;
    
    namespace SO1
    {
        public class GetCategory : IEntities
        {
            private String BaseUri;
    
            public GetCategory(string BaseUri)
            {
                this.BaseUri = BaseUri;
            }
    
            private async Task<string> TaskCategory()
            {
                var httpClient = new HttpClient();
    
                var parameters = new Dictionary<string, string>();
                parameters["text"] = "text";
                
                var response = await httpClient.GetStringAsync(BaseUri);
    
                return response;        
            }
    
            public List<Model.Result> BookCategory()
            {
                List<Model.Result> list = new List<Model.Result>();
    
                var model = JsonConvert.DeserializeObject<Model.RootObject>(TaskCategory().Result);
                
                list = model.results;
    
                return list;
            }
    
        }
    }
