     public static Stopwatch sw;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            sw = new Stopwatch();
            sw.Start();
        }
    }
    protected void Button1_OnClick(object sender, EventArgs e)
    { 
    
    
    
    }
    protected void tm1_Tick(object sender, EventArgs e)
    {
        long sec = sw.Elapsed.Seconds;
        long min = sw.Elapsed.Minutes;
        if (min < 60)
        {
            if (min < 10)
                Label1.Text = "0" + min;
            else
                Label1.Text = min.ToString();
            Label1.Text += " : ";
            if (sec < 10)
                Label1.Text += "0" + sec;
            else
                Label1.Text += sec.ToString();
        }
        else
        {
            sw.Stop();
            Response.Redirect("Timeout.aspx");
        }
    }
