        public class VideoViewModel
        {
            public List<PlayList> PlayList { get; internal set; }
        }
    
    
        public class PlayList
        {
    
            public string Title { get; set; }
            public string Description { get; set; }
            public string Id { get; set; }
            public string Url { get; set; }
            public List<VideoList> VideoList { get; set; }
    
    
        }
    
        public class VideoList
        {
    
            public string Title { get; set; }
            public string Description { get; set; }
            public string Id { get; set; }
            public string Url { get; set; }
            public string PublishedDate { get; set; }
    
        }
