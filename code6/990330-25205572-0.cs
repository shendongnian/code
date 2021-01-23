    private IEnumerable<Team> LoadTeams()
    {
        using (SqlConnection conn = DB.GetSqlConnection())
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SearchForTeam";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
    
                foreach (var key in prms.Keys)
                {
                    cmd.Parameters.Add(key, prms[key]);
                }
    
                SqlDataReader reader 
                          = cmd.ExecuteReader(CommandBehavior.CloseConnection);
    
                while (reader.Read())
                {
                    yield return Load(reader);
                }
            }
        }
    }
    
    public override List<Team> Search(Dictionary<string, string> prms,
                                        int pageSize, int page, out int results) 
    {
        List<Team> searchResult = new List<Team>; 
    
        //Team t = null;
        var tresults = new List<Team>();
    
        foreach(Team team in LoadTeams())
        {
             if (team .....)
                 searchResult.Add(team);
        }
    
        results = 0;
        return searchResult;
    }
