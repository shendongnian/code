    public void end_Click(object sender, EventArgs e)
    {
        DateTime tend = DateTime.Now;
        DateTime tstart = Convert.ToDateTime(Session["BeginEnd"]);
        TimeSpan tspan = tend - tstart;
        SesEnd.Text = tend.ToString();
        Dur.Text = Convert.ToString(tstart);
     }
