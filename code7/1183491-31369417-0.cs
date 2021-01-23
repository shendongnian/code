    private void SaveData() 
    {
        using(var con = new SqlConnection(conString))
        using(var cmd = con.CreateCommand())
        {
            cmd.CommandText = "insert into tbldata values(@date, @text)";
            string[] lines = richTextBox1.Lines;
    
            foreach(var line in lines)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@date", SqlDbType.Datetime).Value = DateTime.Now;
                // Change your first column type to datetime or datetime2
                cmd.Parameters.Add("@text", SqlDbType.NVarChar).Value = line;
                // I assume your second column is nvarchar
                if(con.State != ConnectionState.Open)
                   con.Open();
    
                cmd.ExecuteNonQuery();
            }
        }             
    }
