    protected void Button1_Click(object sender, EventArgs e)
    {
        DataListItem currentItem = ((Button) sender).NamingContainer;
        Image img = (Image)currentItem.FindControl("Img1");
        Label lbl = (Label)currentItem.FindControl("Label1");
        string labeltext = lbl.Text;
        string url = img.ImageUrl;
        Session["type"] = labeltext;
        Session["img"] = url;
        Response.Redirect("WebForm2.aspx");
    }
 
