     public static byte[] ImageToByte(Image img)
            {
                ImageConverter converter = new ImageConverter();
                return (byte[])converter.ConvertTo(img, typeof(byte[]));
            }
      public static void InsertImageintoSqlDatabaseAsBinary(byte[] imgData)
            {
    
    
                using (SqlConnection sqlconnection = new SqlConnection(@"Data Source=.;Initial Catalog=VIP;Trusted_Connection=True;"))
                {
                    sqlconnection.Open();
    
    
                    // Converts image file into byte[]
    
    
                    string insertXmlQuery = @"Insert Into ExpertsInfo (Image) Values(@Photo)";
    
                    // Insert Image Value into Sql Table by SqlParameter
                    SqlCommand insertCommand = new SqlCommand(insertXmlQuery, sqlconnection);
                    SqlParameter sqlParam = insertCommand.Parameters.AddWithValue("@Photo", imgData);
          
                    sqlParam.DbType = DbType.Binary;
                    insertCommand.ExecuteNonQuery();
    
                }
            }
