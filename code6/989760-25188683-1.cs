    public override List<Team> Search(string teamName,string cityName, int pageSize, int page) 
        {
            var tresults = new List<Team>();
    
    
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"Search";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
    
         
                        SqlParameter p1 = new SqlParameter("TeamName", System.Data.SqlDbType.VarChar);
                        p1.Value = teamName;
                        cmd.Parameters.Add(p1);
    
                        SqlParameter p2 = new SqlParameter("CityName", System.Data.SqlDbType.VarChar);
                        p2.Value = cityName;
                        cmd.Parameters.Add(p2);
                    
    
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
    				while(reader.Read())
    				{
    					tresults.Add(BuildTeamFromReader(reader));
    				}
    
                }
            }
            return tresults;
    
        }
    	
    	
    	private Team BuildTeamFromReader(SqlDataReader reader)
    	{
    		var team = new Team();
    		team.TeamName = reader["TeamName"];//or whatever your column name is for team name
    //ToDo other mappings
                return team;
        	}
