        public  void RestoreDatabase(string fileName)
        {
            try 
	        {	        
                using (SqlConnection conn = new SqlConnection("connectionString"))
                {
                    string sql = "RESTORE DATABASE YourDatabase FROM DISK = N''" + fileName;
                    conn.Open();
                    SqlCommand _command = new SqlCommand(sql, conn);
                    _command.ExecuteNonQuery();                
                }
	        }
	        catch (Exception ex)
	        {
                 throw;
	        }
        }
