    
    protected void btnsub_Click(object sender, EventArgs e)
    {
        SqlConnection con = Connection.DBconnection();
        if (Textid.Text.Trim().Length > 0)
        {
            SqlCommand com = new SqlCommand("StoredProcedure3", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", Textid.Text.Trim());
            com.Parameters.AddWithValue("@Name", Textusername.Text.Trim());
            com.Parameters.AddWithValue("@Class", Textclass.Text.Trim());
            com.Parameters.AddWithValue("@Section", Textsection.Text.Trim());
            com.Parameters.AddWithValue("@Address", Textaddress.Text.Trim());
            try
            {
                    
                var filename = string.Format("{0}.{1}", Guid.NewGuid().ToString(), Path.GetExtension(fileupload.PostedFile.FileName).ToLower());
                var full_path = Server.MapPath("~/Images/", filename);
                if (fileupload.PostedFile.FileName.Length > 0)
                {                        ;
                    fileupload.SaveAs(full_path);
                }
                com.Parameters.AddWithValue("@Image", (filename.Length > 0) ? "Images/" + filename : string.Empty);
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                btnsub.Text = ex.Message;
            }
            Response.Redirect("studententry.aspx");
        }
        else
        {
            SqlCommand com = new SqlCommand("StoredProcedure1", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", Textusername.Text.Trim());
            com.Parameters.AddWithValue("@Class", Textclass.Text.Trim());
            com.Parameters.AddWithValue("@Section", Textsection.Text.Trim());
            com.Parameters.AddWithValue("@Address", Textaddress.Text.Trim());
                
            try
            {
                string filename = string.Empty;
                if (fileupload.PostedFile.FileName.Length > 0)
                {
                    var filename = string.Format("{0}.{1}", Guid.NewGuid().ToString(), Path.GetExtension(fileupload.PostedFile.FileName).ToLower());
                    var full_path = Server.MapPath("~/Images/", filename);                        
                    // This IF statement should never be hit since we're using GUID for the file name.
                    if (File.Exists(full_path))
                    {
                        Label6.Visible = true;                            
                        return;
                    }
                    fileupload.SaveAs(full_path);
                }
                com.Parameters.AddWithValue("@Image", (filename.Length > 0) ? "Images/" + filename : string.Empty);
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                btnsub.Text = ex.Message;
            }
            Response.Redirect("studententry.aspx");
        }
    }
