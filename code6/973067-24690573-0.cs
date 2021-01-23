        public List<object> Search(string searchArgument)
        {
            string searchQry = "SELECT (list of columns) FROM dbo.YourTableName WHERE Name = @SearchArg;";
            // Define connection and command to use
            using (SqlConnection conn = new SqlConnection("....."))
            using (SqlCommand cmdSearch = new SqlCommand(searchQry, conn))
            {
                // add parameter to search command - make sure to define NVarChar and a valid length!
                cmdSearch.Parameters.Add("@SearchArg", SqlDbType.NVarChar, 50);
                // set parameter value
                cmdSearch.Parameters["@SearchArg"].Value = searchArgument;
                // open connection, execute query, handle results
                conn.Open();
                using (SqlDataReader rdr = cmdSearch.ExecuteReader())
                {
                    // loop over rows returned
                    while (rdr.Read())
                    {
                        // do something with results - create your objects that you want to return...
                    }
                    // close reader 
                    rdr.Close();
                }
                // close connection
                conn.Close();
            }
        } 
