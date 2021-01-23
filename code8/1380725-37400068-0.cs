    private void timer2_Tick(object sender, EventArgs e)
    {
        Helper.I++;//here accessing static variable
        lblView.Text = Helper.I.ToString() + " Seconds";
    }
 
