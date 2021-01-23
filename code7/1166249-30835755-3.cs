    public bool DeleteMovie(int MovieID)
    {
        string sql = "Delete_DBS2_MOVIE";
        try
        {
            this.Connect();
            OracleCommand cmd = new OracleCommand(sql, this.connection);
            cmd.Parameters.Add(new OracleParameter("p_MOVIE_ID", MovieID));
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
        finally
        {
            this.connection.Close();
        }
        return true;
    }
