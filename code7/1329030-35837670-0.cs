     public void begin_Click(object sender, EventArgs e)
    {
        DateTime tstart = DateTime.Now;
        SesStart.Text = tstart.ToString();
        Session["BeginEnd"] = tstart;
    }
