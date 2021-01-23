    public class Panel
    {
        public bool Visible { get; set; }
    }
    public class MyTest
    {
        public Panel Panel1 = new Panel();
        public void Do()
        {
            string currPanel = "Panel1";
            currPanel += ".Visible";
            SetValue(this, currPanel, true);
        }
    }
