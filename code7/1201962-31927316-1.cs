          if(FileUploadControl.HasFile)
          {
              try
              {
                    string filename = Path.GetFileName(FileUploadControl.FileName);
                    FileUploadControl.SaveAs(Server.MapPath("~/") + filename);
                    StatusLabel.Text = "Upload status: File uploaded!";
              }
              catch(Exception ex)
              {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
              }
         }
