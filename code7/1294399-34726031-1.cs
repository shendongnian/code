    protected void btnCounter_Click(object sender, EventArgs e)
    {
        Session["Clicks"] = Clicks++;
        Label1.Text = Session["Clicks"].ToString();
    }
