         int[] actors = { 7, 8, 9 }; // Actor IDs in database                       
            DataTable dt = new DataTable("movieAndActorType");
            dt.Columns.Add("actorId", typeof(Int32));
            
            for(int i = 0;i <actors.Length; i++)
            {
                var dRow = dt.NewRow();
                dRow["actorId"] = actors[i];
                dt.Rows.Add(actors[i]);                
            }
            var img = new Byte[5];
            try
            {
                using (var conn = new SqlConnection("Your connection string"))
                {
                    using (var cmd = new SqlCommand())
                    {
                        cmd.CommandText = "usp_AddMovie";
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@producerId", SqlDbType.Int).Value =   
                        Convert.ToInt32("99");
                        cmd.Parameters.Add(new SqlParameter { ParameterName = 
                       "@actorIds", SqlDbType = SqlDbType.Structured, Value = dt, 
                        TypeName = "dbo.movieAndActorType" });
                        cmd.Parameters.Add("@movieName", SqlDbType.VarChar).Value 
                        = "Spectre";
                        cmd.Parameters.Add("@yearOfRelease", SqlDbType.Int).Value 
                        = Convert.ToInt32("1972");
                        cmd.Parameters.Add("@plot", SqlDbType.VarChar).Value = 
                        "Some Plot";
                        cmd.Parameters.Add("@image", SqlDbType.Image).Value =                                                             
                        img;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(" SQL error" + ex.Message);
            }
