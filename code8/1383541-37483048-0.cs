     protected void Page_Load(object sender, EventArgs e)
     {
        Timer1.Enabled = true;
        Timer1.Interval = 5000;
     }
     protected void Timer1_Tick(object sender, EventArgs e)
     {
        if(Label1.Text == "name2")
		{
			Label1.Text = "name1";
		}
		else
		{
			Label1.Text = "name2";
		}
     }
