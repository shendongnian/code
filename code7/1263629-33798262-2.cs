    if (FileUpload1.FileName != "")
     {
     FileInfo fi = new FileInfo(FileUpload1.FileName);
     byte[] documentContent = FileUpload1.FileBytes;
    
     string name = fi.Name;
     string extn = fi.Extension;
    
     SqlConnection connections = new SqlConnection(strConn);
     SqlCommand command = new SqlCommand("INSERT INTO tablename(DocumentName, DocumentContent, DocumentExt) VALUES (@DocumentName, @DocumentContent, @DocumentExt)", connections);
    
     SqlParameter param0 = new SqlParameter("@DocumentName", SqlDbType.VarChar);
                  param0.Value = name;
                  command.Parameters.Add(param0);
     SqlParameter param1 = new SqlParameter("@DocumentContent", SqlDbType.VarBinary);
                  param1.Value = documentContent;
                  command.Parameters.Add(param1);
    
     SqlParameter param2 = new SqlParameter("@DocumentExt", SqlDbType.VarChar);
                  param2.Value = extn;
                  command.Parameters.Add(param2);
    connections.Open();
    int numRowsAffected = command.ExecuteNonQuery();
    connections.Close();
    
       if (numRowsAffected != 0)
         {
         Response.Write("<BR>Rows Inserted successfully");
         }
       else
         {
        Response.Write("<BR>An error occurred uploading the image");
         }
      }
    else
    {
    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('No Files Uploaded');", true);
    }
