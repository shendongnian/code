    private static string connString = "Data Source=Server00\\SQLEXPRESS;Initial Catalog=r2;Integrated Security=true;Connect Timeout=0";
	private void populateGameDrop()
	{
		try
		{
			using (var conn = new SqlConnection(connString))
			{
				conn.Open();
				drop_game.Items.Clear();
				using (var cmd = conn.CreateCommand())
				{
					Access ac = (Access)Session["Access"];
                    //TODO
                    //TODO - Introduce parameters to avoid SQL Injection risk
                    //TODO
					cmd.CommandText = "Select name,Abbr from dbo.Games where " + ac.GameQuery;
					using(SqlDataReader r = cmd.ExecuteReader())
                    {
						while (r.Read())
						{
							drop_game.Items.Add(new ListItem(r["name"].ToString(),
        	                                    r["Abbr"].ToString()));
						}
                    }
				}
			}
		}
		catch (Exception exc)
		{
			Log.Error(exc.ToString());
			Session["Error"] = exc.ToString();
			Response.Redirect("~/YouBrokeIt.aspx");
		}
		populateServers();
		SetSplitScreen();
	}
