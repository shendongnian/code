    public class Result 
    {
        public string Title { get; set; }
        public string Id { get; set; }
        public Result() { }
        public Result(string title, string id)
        {
            this.Title = title;
            this.Id = id;
        }
    }
    public class YouTubeViewModel
    {
        public string SearchTerm { get; set; }
        public List<Result> Videos { get; set; }
        public List<Result> Playlists { get; set; }
        public List<Result> Channels { get; set; }
        public YouTubeViewModel()
        {
            Videos = new List<Result>();
            Playlists = new List<Result>();
            Channels = new List<Result>();
        }
        public YouTubeViewModel(string searchTerm)
            :this()
        {
            SearchTerm = searchTerm;
        }
    }
