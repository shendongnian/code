    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        FileUpload fu = 
          ((GridViewRow)((WebControl)sender).NamingContainer)
              .FindControl("fileupload") as FileUpload;
        bool ok = false;
        if (fu != null && fu.HasFile)
        {
            try
            {
                //possible issue here.
                //process NEED PERMISSION to write to this folder
                //also some checks with fu.PostedFile are recommended
                fu.SaveAs(Server.MapPath("~/images/" + fu.FileName));
                ok = true;
            }
            catch (Exception ex)
            {
                ok = false;
            }
        }
        if (ok)
        {
            //update DB table and GridViewRow image field.
        }
    }
