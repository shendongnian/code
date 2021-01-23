    protected void Page_Load(object sender, EventArgs e)
            {
                FileUpload1.Attributes["style"] = "display:none";
            }
    
            protected void UploadButton_Click(object sender, EventArgs e)
            {           
                if (FileUpload1.HasFile)
                {
                    try
                    {
                        string address = Server.MapPath("~/") + FileUpload1.FileName;
                        FileUpload1.PostedFile.SaveAs(address);
                        //...
                    }
                    catch (Exception) { }
                }
            }
