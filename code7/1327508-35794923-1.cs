            private static string Update(string json, object update)
            {
                var updateObj = JObject.Parse(JsonConvert.SerializeObject(update));
    
                var result = new StringWriter();
                var writer = new JsonTextWriter(result);
                writer.Formatting = Formatting.Indented;
    
                var reader = new JsonTextReader(new StringReader(json));
                while (reader.Read())
                {
    
                    if (reader.Value == null)
                    {
                        writer.WriteToken(reader.TokenType);
                        continue;
                    }
    
                    var token= 
                       reader.TokenType == JsonToken.Comment ||
                       reader.TokenType == JsonToken.PropertyName || 
                       string.IsNullOrEmpty(reader.Path)
                       ? null 
                       : updateObj.SelectToken(reader.Path);
    
                    if (token == null)
                        writer.WriteToken(reader.TokenType, reader.Value);
                    else
                        writer.WriteToken(reader.TokenType, token.ToObject(reader.ValueType));
                }
    
                return result.ToString();
            }
    
            static void Main(string[] args)
            {
                string json = @"{
       //broken
       'CPU': 'Intel',
       'PSU': '500W',
       'Drives': [
         'DVD read/writer'
         /*broken*/,
         '500 gigabyte hard drive',
         '200 gigabype hard drive'
       ]
    }";
                
                var update=Update(json, new { CPU = "AMD", Drives = new[] { "120 gigabytes ssd" } });
            }
