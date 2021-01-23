     private static async Task<int> AsyncGet(List<string> entities)
     {
         var tasks = new List<Task<string>>();
          foreach (var entity in entities)
          {
            var t =  AsyncGetResponse(entity);
            tasks.Add(t); 
          }
          await Task.WaitAll(tasks.ToArray()).ConfigureAwait(false);
      }
     static async Task<string> AsyncGetResponse(string entity)
     {
            const string uriTemplate = "https://www.google.co.in/?#q={0}";
            Uri uri = new Uri(string.Format(uriTemplate, entity));
            var request  = WebRequest.Create(uri);
            var response = (HttpWebResponse)await task1.ConfigureAwait(false);
            return await (string) new StreamReader(response.GetResponseStream()).ReadToEndAsync().ConfigureAwait(false);
            
     }
