    // Build your connection
    using(var connection = new SqlConnection("{your-connection-string-here"}))
    {
         // Build your query
         var query = "SELECT [MNavID], [DisplayLabel],[Priority] FROM [MainNavLevel1] ORDER BY [Priority]";
         // Create a command to execute your query
         using(var command = new SqlCommand(query,connection))
         {
              // Open the connection
              connection.Open();
              // Execute your query here (in this case using a data reader)
              using(var reader = command.ExecuteReader())
              {
                    // Create a list of items to use in your View (assumes this class exists)
                    var navigationLabels = new List<NavigationLabel>();
                    // Iterate through your results
                    while(reader.Read())
                    {
                          // Build a navigation item for each row returned from
                          // your query
                          navigationLabels.Add(new NavigationLabel(){
                               MNavID = reader["MNavID"],
                               DisplayLabel = reader["DisplayLabel"],
                               Priority = reader["Priority"]
                          });
                    }
                    // Pass your labels to your View
                    return View(navigationLabels);
              }
         }
    }
