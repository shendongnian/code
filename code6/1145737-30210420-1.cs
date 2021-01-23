    // SearchMovie method
    public async Task MovieSearch(string search)
    {          
        System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        var baseAddress = new Uri("http://api.themoviedb.org/3/");
        using (var httpClient = new HttpClient { BaseAddress = baseAddress })
        {     
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");
            // api_key can be requestred on TMDB website
            using (var response = await httpClient.GetAsync("search/movie?api_key=941c...&query=" + search))
            {
                string responseData = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<RootObject>(responseData);
                foreach (var result in model.results)
                {
                    // All movies
                    // System.Diagnostics.Debug.WriteLine(result.title);
                }      
            }
        }
    }
    // Generated model from json2csharp.com
    public class Result
    {
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public int id { get; set; }
        public string original_title { get; set; }
        public string release_date { get; set; }
        public string poster_path { get; set; }
        public double popularity { get; set; }
        public string title { get; set; }
        public bool video { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }
    }
    public class RootObject
    {
        public int page { get; set; }
        public List<Result> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
    // Examle of search functionaly in View
    @Html.ActionLink("Search movie", "MovieSearch", new { search = "mission"})
