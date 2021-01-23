        string xmlData = new System.Net.WebClient().DownloadString("http://timesofindia.indiatimes.com/rssfeedstopstories.cms");
        string sqlForInsert = "INSERT INTO TableName (xmlDataField) VALUES (@xmlData);";
        int rowsAffected = 0;
        try
        {
            using (SqlConnection con = new SqlConnection("<ConnectionString>"))
            using (SqlCommand cmd = new SqlCommand(sqlForInsert, con))
            {
                cmd.Parameters.Add(new SqlParameter("xmlData", xmlData));
                con.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex) {
            //Exception Handling
        }
        if (rowsAffected > 0)
        {
            //Successful
        }
        else {
            //unsuccesfull
        }
