    public class MenuItem
    {
        public string Text { set; get; }
        public string TargetUrl { set; get; }
        public List<MenuItem> Childs { set; get; }
        public MenuItem()
        {
            this.Childs=new List<MenuItem>();
        }
    }
