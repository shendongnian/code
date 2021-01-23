    using(var command = new SqlCommand())
    {
         /*init your sql command */
         var dataSet = new DataSet("Games");
         var dataAdapter = new SqlDataAdapter();
         /*set data adapter command (your query)*/
         dataAdapter.Fill(dataSet);
         var games = new List<Game>();
         
         var groupings = dataSet.Tables[0].Cast<DataRow>().GroupBy(x => x["Game"].ToString()); //Here we are grouping by games. Based on your example we'll have one group "Assassin's Creed". 
         foreach(var grouping in groupings)
         {
              var firstRow = grouping.First();
              var game = new Game()
              {
                   Title = firstRow["Game"].ToString(),
                   Genre = string.Join(",", grouping.GroupBy(x => x["Genre"]).Select(x => x.First()["Genre"].ToString()), //Grouping eliminates dupes. This should return Action, Stealth based on your example
                   Platform = string.Join(",", grouping.GroupBy(x => x["Platform"]).Select(x => x.First()["Platform"].TosString()),
                   Developer = firstRow["Developer"].ToString() //I'm assuming each game has exactly one developer
              }
              games.Add(game);
        }
        //The games list should now have exactly what you need. Based on your example it would have only looped once since there is only one game so you'll have a list with one game object
    }
