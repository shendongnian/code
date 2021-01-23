    public class Slide
    {
        public bool HasTitle { get; private set; }
    
        public double runningTime
        {
            get;
            set;
        }
    
        private string _title;
    
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
