        [HttpPost]
        [Route ( "getProducts" )]
       
        public HttpResponseMessage GetProducts ( HttpRequestMessage request )
        {
            HttpResponseMessage  message               = null;
            string               input                 = string.Empty;
           
            input  = request.Content.ReadAsStringAsync ().Result;
             var ids = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>> ( input );
        }
    }
