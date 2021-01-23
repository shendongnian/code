    public class Artwork
    {
        private static string defaultAtwork = "https://pixabay.com/static/uploads/photo/2016/01/06/07/06/bokeh-1123696_960_720.jpg";
        private string _small = defaultAtwork;
        private string _medium = defaultAtwork;
        private string _large = defaultAtwork;
        private string _default = defaultAtwork;
        public string small
        {
            get { return _small; }
            set { _small = value; }
        } 
        ...
    }
    public class Album
    {
        private Artwork _artwork = new Artwork();
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public Artwork artwork
        {
            get { return _artwork; }
            set { _artwork = value; }
        }
