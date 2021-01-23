      public interface IGetData
      {
           Task<string> GetApiData();
      }
      public class GetData : IGetData
      {
        public async Task<string> GetApiData()
        {
          var client = new HttpClient();
          var response = await client.GetAsync(string.Format("http://mysite/api/Data"));
          var responseString = await response.Content.ReadAsStringAsync();
          return responseString; 
        }
       }
