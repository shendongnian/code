    public class MyClass
    {
        public MyClass(IApiRequest api)
        {
            this.api = api; 
        }
    }
        public async Task<UpcomingMovies> GetUpcomingMovies(int page)
        {
            var request = new RestRequest
            {
                Resource = "movie/upcoming",
            };
            request.AddParameter("page", page.ToString());
            request.AddParameter("language", "en");
            return await api.ExecuteAsync<UpcomingMovies>(request);
        }
    }
