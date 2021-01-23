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
        var timer = //some timer set up to tick every 20 seconds
        timer.Start();
        label18.Text = "Timer Activated";
    }
    private void Refresh_App_TimerNH_Tick(object sender, EventArgs e)
    {
        pairs[refreshIndex].WebBrowser.Refresh();
        pairs[refreshIndex].UserIdLabel.BackColor = Color.Red;
        label20.Text = "+" + (refreshIndex + 1);
        refreshIndex = (refreshIndex + 1) % pairs.Count;
    }
