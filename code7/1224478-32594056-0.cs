     protected void Page_Load(object sender, EventArgs e)
     {
        if(Request.IsSecureConnection)
        {
            SocialShareElements shareElement = LoadControl("SocialShareElements.ascx") as SocialShareElements;
            socialDiv.Controls.Add(shareElement);
        }
     }
