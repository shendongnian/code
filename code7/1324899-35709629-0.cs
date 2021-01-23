    public Musician GetMusician(int recordId)
    {
        Musician objMusician = null;
        using(SqlConnection con = new SqlConnection(_connectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "selectMusician";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", recordId);
                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        objMusician = new Musician((int) reader["id"]);
                        objMusician.Name = (string) reader["name"];
                    }
                    if objMusician != null)
                    {
                        objMusician.Albums = Albums.GetAlbums((int)objMusician.ID);
                        objMusician.Tours = Tours.GetTours((int)objMusician.ID);
                        objMusician.Interviews = Interviews.GetInterviews((int)objMusician.ID);
                    }
                }
            }
            return objMusician;
        }
    }
