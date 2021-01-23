    // You need interface to keep your repository usage abstracted
    // from concrete implementation as this is the whole point of 
    // repository pattern.
    public interface IUserRepository
    {
        Task<User> GetUserAsync(int userId);
    }
    public class UserRepository : IUserRepository
    {
        private static string baseUrl = "https://example.com/api/"
        public async Task<User> GetUserAsync(int userId)
        {
            var userJson = await GetStringAsync(baseUrl + "users/" + userId);
            // Here I use Newtonsoft.Json to deserialize JSON string to User object
            var user = JsonConvert.DeserializeObject<User>(userJson);
            return user;
        }
        private static async Task<string> GetStringAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync(url);
            }
        }
    }
