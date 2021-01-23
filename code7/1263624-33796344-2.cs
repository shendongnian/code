    if(FileUpload1.HasFile)//To check file os present
    {
    	if(FileUpload1.PostedFile.ContentLength > 0)
                    {
    			        FileInfo fi = new FileInfo(FileUpload1.FileName);
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
