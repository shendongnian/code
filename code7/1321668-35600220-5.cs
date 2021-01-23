    public class MyViewModel
    {
        private string displayTime=DateTime.Now.ToString;
        public string DisplayTime
        {
            get { return displayTime; }
            set { displayTime = value; }
        }
    }
