    public class WebHelper
    {
       public async Task<string> MakePostRequest(HttpClient client, string route, object dataToBeSent)
       {
          try{
                HttpResponseMessage response = await client.PostAsJsonAsync(route, datatobeSent);
                string resultData = await response.Content.ReadAsStringAsync();
                return resultData;
          }
          catch (Exception ex){
             return ex.Message;
        }
      }
    }
    
