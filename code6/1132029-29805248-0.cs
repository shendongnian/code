     string filename = System.IO.Path.GetFileName(FileUpload1.FileName);
     string ext = System.IO.Path.GetExtension(FileUpload1.FileName);
     if (fileExtension == ".txt"){
               using (System.IO.FileStream fs = new System.IO.FileStream(Server.MapPath(("C:\\inetpub\\wwwroot\\Viber_Bulk_UI\\Upload\\" + FileName), System.IO.FileMode.Append, System.IO.FileAccess.Write, System.IO.FileShare.Read, 8, System.IO.FileOptions.None))
            {
                byte[] data = System.Text.Encoding.ASCII.GetBytes(FileName);
                fs.Write(data, 0, data.Length);
                fs.Flush();
                fs.Close();
            }
      }
