        public Form1()
        {
            InitializeComponent();
            string textThatWouldBeInATextBoxOnTheUserInterface = "1234,4567,789";//lets pretend this is the textbox value entered by the user
            string[] GUIDs = textThatWouldBeInATextBoxOnTheUserInterface.Split(',').ToArray();//split that string into a string[]
            List<string> listOfResults = new List<string>();//create something to hold your results
            
            //iterate through each string
            foreach (string item in GUIDs)
            {
                listOfResults.Add(getTheData(item));//add results to your list
            }
        }
        private string getTheData(string incomingID)
        {
            List<string> dbConnStrings = new List<string>();
            dbConnStrings.Add(@"Provider=SQLOLEDB;Server=ServerName\Schema;Database=dbName1;User Id=uid;Password=pwd;");
            dbConnStrings.Add(@"Provider=SQLOLEDB;Server=ServerName\Schema;Database=dbName2;User Id=uid;Password=pwd;");
            string sqlQuery = "select whatever from TheTable where MyRestriction = " + incomingID;
            bool HaveYouFoundItYet = false;
            int TrackMyPositionInTheList = 0;
            string queryResults = string.Empty;
            while (!HaveYouFoundItYet && TrackMyPositionInTheList < dbConnStrings.Count)//while you haven't found it and there are still DBs to look into
            {
                using (OleDbConnection currentConnection = new OleDbConnection(dbConnStrings[TrackMyPositionInTheList]))//look into the DB determined by the PositionTracker
                {
                    currentConnection.Open();
                    OleDbCommand command = new OleDbCommand(sqlQuery, currentConnection);
                    if (command.ExecuteScalar() != null)//if you found what you're looking for
                    {
                        queryResults = command.ExecuteScalar().ToString();//do whatever with your pulled data
                        HaveYouFoundItYet = true;//make the while loop stop
                    }
                    else
                    {
                        TrackMyPositionInTheList++;//Lets increment the PositionTracker by 1 and look again.
                    }
                }
            }
            return queryResults;
        }
