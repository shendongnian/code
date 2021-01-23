    using (con)
    {
        con.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            reader.Read();
            objMusician = new Musician((int)reader["id"]);
            objMusician.Name = (string)reader["name"];
        }
        if objMusician != null)
        {
            objMusician.Albums = Albums.GetAlbums((int)objMusician.ID);
            objMusician.Tours = Tours.GetTours((int)objMusician.ID);
            objMusician.Interviews = Interviews.GetInterviews((int)objMusician.ID);
        }
        con.Close();
        cmd.Dispose();        
        return objMusician;
    }
        
