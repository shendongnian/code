    public class Slide
    {
        public bool HasTitle { get; set; }
    
        public double runningTime
        {
            get;
            set;
        }
    
        public string _title;
    
        public string title
        {
            get { return _title;  }
            set { _title = value; HasTitle = true; }
        }
    
        public int id
        {
            get;
            set;
        }
    }
