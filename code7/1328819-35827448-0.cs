    protected void ImageButtonPrevDate_Click(object sender, ImageClickEventArgs e)
    {
        DateTime date = Session["MyDateVariable"] as DateTime ?? DateTime.Now;
        DateTime nextday = date.AddDays(-1);
        Session["MyDateVariable"] = nextday;
        txtDate.Text = nextday.ToShortDateString();
    }
