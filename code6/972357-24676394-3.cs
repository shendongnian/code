    public bool IsValid(HttpPostedFile file)
    {
        var validExtensions = { ".jpg", ".gif", ".png" };
        var fileExtension = System.IO.Path.GetExtension(file.FileName);
        if (Array.IndexOf(validExtensions, fileExtension.ToLower()) < 0)
        {
            return false;
        }
        var size = file.ContentLength / 1024;
        if (size == 0 || size > 2024)
        {
            return false;
        }
    }
    private bool TryUploadFile(HttpPostedFile file, out string filename)
    {
        var path = Server.MapPath(".") + "\\newspic\\";
        filename = path + System.IO.Path.GetFileName(file.FileName);        
        if (!IsValid(file))
        {
            return false;
        }
        
        try 
        {
            file.SaveAs(filename);
        }
        catch (HttpException)
        {
            return false;
        }
    }
    private bool TryInsertFile(string title, string text, string id_writer, string filename)
    {
        using (var conn = new SqlConnection("<connectionString>"))
        {    
            try
            {            
                var now = DateTime.Now;
                
                conn.Open();
            
                var qry = "INSERT INTO tbl (title, day, month, year, text, id_writer, pic)" + 
                          "VALUES (@title, @day, @month, @year, @text, @id_write, @pic)"
                          
                var cmd = new SqlCommand()
                
                cmd.Parameters.Add(new SqlParameter("@title", title));
                cmd.Parameters.Add(new SqlParameter("@day", now.Day));
                cmd.Parameters.Add(new SqlParameter("@month", now.Month));
                cmd.Parameters.Add(new SqlParameter("@year", now.Year));
                cmd.Parameters.Add(new SqlParameter("@text", text));
                cmd.Parameters.Add(new SqlParameter("@id_writer", id_writer));
                cmd.Parameters.Add(new SqlParameter("@pic", filename));
        
                cmd.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }
