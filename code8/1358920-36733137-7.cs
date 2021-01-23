     protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Response.Write("File has been passed");
        Button bts = e.CommandSource as Button;
        Response.Write(bts.Parent.Parent.GetType().ToString());
        if (e.CommandName.ToLower() != "upload")
        {
            return;
        }
        FileUpload fu = bts.FindControl("FileUpload1") as FileUpload;//here
        if (fu.HasFile)
        {
            bool upload = true;
            string fileName = Path.GetFileName(fu.PostedFile.FileName);
            string fleUpload = Path.GetExtension(fu.PostedFile.FileName);
            if (fleUpload.Trim().ToLower() == ".xls" || fleUpload.Trim().ToLower() == ".xlsx")
            {
                fu.SaveAs(Server.MapPath("~/UpLoadPath/" + fileName));
                string uploadedFile = (Server.MapPath("~/UpLoadPath/" + fileName ));
                //Someting to do?...
            }
            else
            {
                upload = false;
                // Something to do?...
            }
            if (upload)
            {
                // somthing to do?...
            }
        }
        else
        {
            //Something to do?...
        }
    } 
