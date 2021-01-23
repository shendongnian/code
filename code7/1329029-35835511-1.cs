    // Button to end the Session
    public void end_Click(object sender, EventArgs e)
    {
        DateTime tend = DateTime.Now;
        var tstart = Session["StartTime"] as DateTime; // see this                      
        TimeSpan tspan = tend - tstart;
        SesEnd.Text = tend.ToString();
        Dur.Text = Convert.ToString(tstart);
     }
