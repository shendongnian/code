     public interface ICustomer
      {
           Task<string> GetCustomers();
      }
      public class ICustomerService : ICustomer
      {
        public async Task<string> GetCustomers()
        {
          var client = new HttpClient();
          var response = await client.GetAsync(string.Format("http://mysite/api/Customer"));
          var responseString = await response.Content.ReadAsStringAsync();
          return responseString; 
        }
       }
