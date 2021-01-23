    private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
    {
        rtbDocument.Clear();
    
        // set up your connection string (typically from a config) and query text
        string connString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\User\Desktop\myproject_c#\diary\photogallery\RicherTextBox_src\RicherTextBox\diary.mdf;Integrated Security=True;User Instance=True;";
        string query = "SELECT rtf_file_content FROM rtf WHERE rtf_date=@dt AND user_rtf_id=1";
        
        // set up connection and command - both are disposable, put them in a "using" block
        using (SqlConnection cn = new SqlConnection(connString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            // set up parameter for query
            // define the parameter to be a "DateTime" parameter
            // set value directly from a "DateTime" property of your "monthCalendar1"
            cmd.Parameters.Add("@dt", SqlDbType.DateTime).Value = monthCalendar1.SelectionStart;
            
            // open connection, execute reader...
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                // loop over reader - reading all rows being returned by query
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                         Byte[] rtf = new Byte[Convert.ToInt32((reader.GetBytes(0, 0, null, 0, Int32.MaxValue)))];
                         long bytesReceived = reader.GetBytes(0, 0, rtf, 0, rtf.Length);
                         ASCIIEncoding encoding = new ASCIIEncoding();
                         rtbDocument.Rtf = encoding.GetString(rtf, 0, Convert.ToInt32(bytesReceived));
                    }
                }
            }
        }
    }
     
