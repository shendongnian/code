       using Newtonsoft.Json;
                    
        private class FormField
        {
            [JsonProperty("name")]
            public string a { get; set; }
                        
            [JsonProperty("value")]
            public string b { get; set; }
                        
        }
                    
        private void ReadFormData(string sFormData)
        {
                //this will throw if you give two form fields the same name in your HTML.
                Dictionary<string,string> asFormData = JsonConvert.DeserializeObject<List<FormField>>(sFormData).ToDictionary(x => x.a, x => x.b);
                    
                     
               //VALUES OF FORM ELEMENTS NOW ACCESSIBLE BY NAME IN DICTIONARY 
               string sSearchText = asFormData["txtsearch"];
    }
