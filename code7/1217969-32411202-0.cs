    public class MyPlace
    {
        public List<Video> videos { get; set; }
    
        public Video MyFirstVideo
        {
            get
            {
                return videos.FirstOrDefault();
            }
        }
    }
