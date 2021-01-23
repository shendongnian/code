    string connectionstring = "Data Source=94.126.71.192;Initial Catalog=JasperTest;Persist Security Info=True;User ID=ID;Password=*********;MultipleActiveResultSets=True;Application Name=EntityFramework";
                            
                             using (var conn = new System.Data.SqlClient.SqlConnection(connectionstring))
                             {
                                 var cmd = new System.Data.SqlClient.SqlCommand("INSERT INTO Importtesttabel (valuedateimport) VALUES (@bar)", conn);
                                 cmd.Parameters.AddWithValue("@bar", valuedateimport);
                                 conn.Open();
                                 cmd.ExecuteNonQuery();
                             }
