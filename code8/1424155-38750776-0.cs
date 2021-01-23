            //Make a list of the DBs to connect to
            List<string> dbConnStrings = new List<string>();
            dbConnStrings.Add(@"Provider=SQLOLEDB;Server=ServerName\Schema;Database=dbName;User Id=uid;Password=pwd;");
            dbConnStrings.Add(@"Provider=SQLOLEDB;Server=ServerName\Schema;Database=dbName;User Id=uid;Password=pwd;");
            string sqlQuery = "select whatever from TheTable where MyRestriction = 'match'";
            bool HaveYouFoundItYet = false;//We'll use this to stop the while loop when we find what we need
            int TrackMyPositionInTheList = 0;//This will track which position of the List we are at
            string queryResults = string.Empty;//somewhere to store the result
            while (!HaveYouFoundItYet && TrackMyPositionInTheList < dbConnStrings.Count)//while you haven't found it and there are still DBs to look into
            {
                using (OleDbConnection currentConnection = new OleDbConnection(dbConnStrings[TrackMyPositionInTheList]))//look into the DB determined by the PositionTracker
                {
                    currentConnection.Open();
                    OleDbCommand command = new OleDbCommand(sqlQuery.ToString(), currentConnection);
                    if (command.ExecuteScalar() != null)//if you found what you're looking for
                    {
                        queryResults = command.ExecuteScalar().ToString();//do whatever with your pulled data
                        HaveYouFoundItYet = true;//make the while loop stop
                    }
                    else
                    {
                        TrackMyPositionInTheList++;//if you reach this, you haven't found what you were looking for. Lets increment the PositionTracker by 1 and look again.
                    }
                }
            }
