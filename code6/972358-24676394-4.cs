    private void UploadPicture(HttpPostedFile file, string title, string text, string id_writer)
    {
        if (!IsValid(file)) return;
    
        using (var conn = new SqlConnection(/* connection string */))
        {    
            conn.Open();
            
            // begin a transaction which will be rolled back if not committed
            using (var tx = conn.BeginTransaction())
            {            
                var now = DateTime.Now;                
            
                var insert = "INSERT INTO tbl (title, day, month, year, text, id_writer, pic)" + 
                             "VALUES (@title, @day, @month, @year, @text, @id_write, @pic);" +
                             "SELECT SCOPE_IDENTITY();";
                             
                var update = "UPDATE tbl SET pic = @pic WHERE id = @id";
                          
                var insertCommand = new SqlCommand(insert);
                
                var updateCommand = new SqlCommand(update);
                
                // insert the row for the uploaded file
                insertCommand.Parameters.Add(new SqlParameter("@title", title));
                insertCommand.Parameters.Add(new SqlParameter("@day", now.Day));
                insertCommand.Parameters.Add(new SqlParameter("@month", now.Month));
                insertCommand.Parameters.Add(new SqlParameter("@year", now.Year));
                insertCommand.Parameters.Add(new SqlParameter("@text", text));
                insertCommand.Parameters.Add(new SqlParameter("@id_writer", id_writer));
        
                // get the identity of the inserted row
                var identity = Convert.ToInt32(insertCommand.ExecuteScalar());
                
                // get the filename appending the identity
                var path = Server.MapPath(".") + "\\newspic\\";
                
                var filename =  path + System.IO.Path.GetFileName(file.FileName) + identity;
                
                // update the row with the filename
                updateCommand.Parameters.Add(new SqlParameter("@pic", filename));
                updateCommand.Parameters.Add(new SqlParameter("@id", identity));
                
                updateCommand.ExecuteNonQuery();
                
                // save the file
                file.SaveAs(filename);
                
                // all done so commit
                tx.Commit();
            }
        }
    }
