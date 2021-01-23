    public class Result
    {
        public int id { get; set; }
        public string title { get; set; }
        public int release_year { get; set; }
        public int themoviedb { get; set; }
        public string original_title { get; set; }
        public List<object> alternate_titles { get; set; }
        public string imdb { get; set; }
        public bool pre_order { get; set; }
        public bool in_theaters { get; set; }
        public string release_date { get; set; }
        public string rating { get; set; }
        public int rottentomatoes { get; set; }
        public string freebase { get; set; }
        public int wikipedia_id { get; set; }
        public string metacritic { get; set; }
        public string common_sense_media { get; set; }
        public string poster_120x171 { get; set; }
        public string poster_240x342 { get; set; }
        public string poster_400x570 { get; set; }
    }
    public class RootObject
    {
        public int total_results { get; set; }
        public int total_returned { get; set; }
        public List<Result> results { get; set; }
    }
