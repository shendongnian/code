    protected void ImageButtonNextDate_Click(object sender, ImageClickEventArgs e)
    {
    	txtDate.Text = (Convert.ToDateTime(txtDate.Text).AddDays(1)).ToShortDateString();					
    }
    protected void ImageButtonPrevDate_Click(object sender, ImageClickEventArgs e)
    {
        txtDate.Text = (Convert.ToDateTime(txtDate.Text).AddDays(-1)).ToShortDateString();			
    }
