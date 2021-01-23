    protected void btn1_ServerClick(object sender, EventArgs e)
    {
        HtmlButton btn = (HtmlButton)sender;
        btn.InnerText = btn.ID;
    }
