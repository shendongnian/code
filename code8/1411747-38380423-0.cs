    public interface IUserRepository
    {
        Task<User> GetUserAsync(int userId);
    }
    public UserRepository : IUserRepository
    {
        private static string baseUrl = "https://example.com/api/"
        public async Task<User> GetUserAsync(int userId)
        {
            var userString = await GetStringAsync(baseUrl + "users/" + userId);
            // Here I use Newtonsoft.Json to deserialize JSON string to User object
            var user = JsonConvert.DeserializeObject(userString);
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
