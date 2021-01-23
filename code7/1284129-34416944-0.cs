    protected void InsertAttachments(int ID)
    {
        HtmlGenericControl Div = new HtmlGenericControl("div");
        HtmlGenericControl Img = new HtmlGenericControl("img");
        try
        {
            string[] ImageArray = Directory.GetFiles(Server.MapPath("./UploadedPictures"), "*_*_" + ID + "_*.jpeg", SearchOption.AllDirectories);
            try
            {
                foreach (var Picture in ImageArray)
                {
                    Div = new HtmlGenericControl("Div");
                    Div.Attributes["class"] = "col-lg-3 col-md-4 col-xs-6 thumb";
                    Img = new HtmlGenericControl("img");
                    Img.Attributes["class"] = "img-responsive";
                    Img.Attributes.Add("src", Picture);
                    IMGContainer.Controls.Add(Div);
                    Div.Controls.Add(Img);
                }
            }
            catch (Exception)
            {
            }
        }
        catch (Exception)
        {
        }
    }
