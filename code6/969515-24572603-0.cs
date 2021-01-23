    public void rt_chnaged(object sender, AjaxControlToolkit.RatingEventArgs e)
    {
        Rating rating = (Rating) sender;
        DataListItem item = (DataListItem) rating.NamingContainer;
        Label lbl = (Label) item.FindControl("Label2");
        Label3.Text = lbl.Text;
    }
