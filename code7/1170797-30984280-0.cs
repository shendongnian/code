            string connectionString = "Server=tcp: [xxxxx].database.windows.net,1433;Database=[xxxxx];User ID=[xxxxx]@[xxxxx];Password=[xxxxx];Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                SqlDataReader reader = null;
                SqlCommand myCommand = new SqlCommand("SELECT [xxxxx] FROM [xxxxx]", myConnection);
                reader = myCommand.ExecuteReader();
                if (!(reader.Read()))
                    throw new Exception("[xxxxx] not found.");
                else
                    cert = reader["[xxxxx]"].ToString();
                myConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
