     public static void InsertXMlDataIntoTableBySQLParameter()
        {
            using (SqlConnection sqlconnection = new SqlConnection(@"Data Source=.\SQLExpress; 
        Initial Catalog=MorganDB; Integrated Security=SSPI;"))
            {
                sqlconnection.Open();
         
                // create table if not exists 
                string createTableQuery = @"Create Table [MyTable] ( ID int, [myXmlColumn] xml)";
                SqlCommand command = new SqlCommand(createTableQuery, sqlconnection);
                command.ExecuteNonQuery();
               //whateever xml data 
                string xmlData = "<XmlRoot><childNode></childNode></XmlRoot>";
         
                string insertXmlQuery = @"Insert Into [MyTable] (ID,[myXmlColumn]) Values(1,@myXmlColumn)";
         
              // Insert XMl Value into Sql Table by SqlParameter
                SqlCommand insertCommand = new SqlCommand(insertXmlQuery, sqlconnection);
                SqlParameter sqlParam = insertCommand.Parameters.AddWithValue("@myXmlColumn", xmlData);
                sqlParam.DbType = DbType.Xml;
                insertCommand.ExecuteNonQuery();
            }
        }
