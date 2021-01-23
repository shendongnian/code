    protected void Page_Load(object sender, EventArgs e)
    {
        Timer1.Enabled = true;
        Label1.Text = "name1";
        Timer1.Interval = 2000;
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        Label1.Text = "name2";
        Timer1.Enabled = false;
    }
