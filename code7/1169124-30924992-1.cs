    public class MyPair
    {
        public WebBrowser WebBrowser { get; set; }
        public Label UserIdLabel { get; set; }
    }
    private List<MyPair> pairs;
    private int refreshIndex = 0;
    private void StartTimer()
    {
        pairs = // populate pairs somehow
        refreshIndex = 0;
        var timer = new System.Windows.Forms.Timer();
        timer.Interval = 20000
        timer.Tick += MyTickHandler;
        timer.Start();
        label18.Text = "Timer Activated";
    }
    private void MyTickHandler(object sender, EventArgs e)
    {
        pairs[refreshIndex].WebBrowser.Refresh();
        pairs[refreshIndex].UserIdLabel.BackColor = Color.Red;
        label20.Text = "+" + (refreshIndex + 1);
        refreshIndex = (refreshIndex + 1) % pairs.Count;
    }
