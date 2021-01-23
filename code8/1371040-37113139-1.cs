    ...
    ...
    ...
    
    public void sqlTest()
    {
        string connectionString = "server=localhost;database=test;UserId=root;password=test;";
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
			string query = @"DROP TABLE test IF EXISTS;
							CREATE TABLE `test`(
						   `test1` DOUBLE(13,2),
						   `test2` DOUBLE(13,2),
						   `test3` DOUBLE(13,2),
						   `test4` DOUBLE(13,2) );";
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {               
                cmd.ExecuteNonQuery();
				string[] files = Directory.GetFiles("D:/computer/csv files", "*.csv");
                foreach (string file in files)
                {
                   query =@"LOAD DATA INFILE '"+file+"' INTO TABLE test
							FIELDS TERMINATED BY ','
							LINES TERMINATED BY '\r\n'
							IGNORE 1 LINES"; 
					using (MySqlCommand cmd1 = new MySqlCommand(query, connection))
					{ 	
						cmd1.ExecuteNonQuery();
					}					
                }
            }
            
        }
    }
    ...
    ...
    ...
