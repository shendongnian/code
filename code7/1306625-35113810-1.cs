    protected void ViewEmployeeDetails_DataBound(object sender, EventArgs e)
        {
            Image img = ViewEmployeeDetails.FindControl("Image1") as Image;
            string url = img.ImageUrl;
            string modified = url + "?time=" + DateTime.Now.ToString();
            img.ImageUrl = modified;
        }
