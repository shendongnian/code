     public static async  Task  insert(string id, string type, string cat)
                {
           WebClient wc = new WebClient();
                    wc.Headers[HttpRequestHeader.ContentType] = "application/json";
        
                
               var responce=     await wc.UploadStringTaskAsync(uri, "POST", json);
                 jsons = responce.ToString().Trim();
        
                 saving();//save to database logic here
        }
