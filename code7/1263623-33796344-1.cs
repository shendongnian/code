      ListBox lbAttachments = (ListBox)FileUpload1;
      if(lbAttachments.Items.Count > 0)
      {
             for(int i = 0; i < lstAttachments.Items.Count; i++)
             {
                   FileInfo fi = new FileInfo(lbAttachments.Items[i].Text);
                   byte[] documentContent = FileUpload1.FileBytes;
    
                   string name = fi.Name;
                   string extn = fi.Extension;
    
                   da.InsertCommand.Parameters.Add("@DocumentName", SqlDbType.VarChar).Value = name;
                   da.InsertCommand.Parameters.Add("@DocumentContent", SqlDbType.VarBinary).Value = documentContent;
                   da.InsertCommand.Parameters.Add("@DocumentExt", SqlDbType.VarChar).Value = extn;
    
                   cs.Open();
                   da.InsertCommand.ExecuteNonQuery();
                   cs.Close();
             } 
       }
