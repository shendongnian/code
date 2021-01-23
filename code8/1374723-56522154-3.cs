 
    // Convert all request perameter into Json object
    
                    var content = req.Content;
                    string jsonContent = content.ReadAsStringAsync().Result;
                    dynamic requestPram = JsonConvert.DeserializeObject<AzureSqlTableClass>(jsonContent);
    
                    // Validate required param
    
                    if (string.IsNullOrEmpty(requestPram.FirstName))
                    {
                        return req.CreateResponse(HttpStatusCode.OK, "Please enter First Name!");
                    }
                    if (string.IsNullOrEmpty(requestPram.LastName))
                    {
                        return req.CreateResponse(HttpStatusCode.OK, "Please enter Last Name!");
                    }
    
    
    
                    //Read database Connection
    
                    var sqlConnection = Environment.GetEnvironmentVariable("sqldb_connection");
                    var responseResults = 0;
    
                    //Read Write Uisng Connection String
    
                    using (SqlConnection conn = new SqlConnection(sqlConnection))
                    {
                        conn.Open();
                        var text = "INSERT INTO AzureSqlTable VALUES ('" + requestPram.FirstName + "', '" + requestPram.LastName + "', '" + requestPram.Email + "') ";
    
                        using (SqlCommand cmd = new SqlCommand(text, conn))
                        {
                            responseResults = await cmd.ExecuteNonQueryAsync();
                        }
                        conn.Close();
                    }
    
                    return req.CreateResponse(HttpStatusCode.OK, responseResults);
