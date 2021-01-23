     public class NewsViewModel
     {
        public NewsViewModel()
        {
            this.Categories = new List<Category>();
        }
        public int NewsId { get; set; }
        public string NewsTitle { get; set; }
        public string NewsBody { get; set; }
    
        public IList<Category> Categories { get; set; }
    
    }
