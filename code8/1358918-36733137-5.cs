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
            string fleUpload = Path.GetExtension(fu.FileName.ToString());
            if (fleUpload.Trim().ToLower() == ".xls" || fleUpload.Trim().ToLower() == ".xlsx")
            {
                fu.SaveAs(Server.MapPath("~/UpLoadPath/" + fu.FileName.ToString()));
                string uploadedFile = (Server.MapPath("~/UpLoadPath/" + fu.FileName.ToString()));
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
