    public static bool IsValidImage(string url)
           {
               var request = (HttpWebRequest)HttpWebRequest.Create(url);
               request.Method = "HEAD";
               using (var response = request.GetResponseAsync().Result)
               {
                   return response.ContentType.ToLower().StartsWith("image/");
    
               }
           }
