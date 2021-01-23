    var command = @"SELECT name,
                           CreationDate        
                      FROM customer
                     ORDER BY
                           CreationDate      
                     OFFSET @skip ROWS
                     FETCH NEXT @take ROWS ONLY;";
    
                using (var conn = new SqlConnection("Data Source=.;Initial Catalog=Stackoverflow;Integrated Security=True"))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("skip", 0);
                        cmd.Parameters.AddWithValue("take", 10);
    
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetString(0));
                        }
                    }
                }
