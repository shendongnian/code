        /// <summary>
        /// this way should be faster than the previous one
        /// because we won't connect to the same DB more than once.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            //string textThatWouldBeInATextBoxOnTheUserInterface = "30439,30447,32273,32270";//lets pretend this is the textbox value entered by the user
            string textThatWouldBeInATextBoxOnTheUserInterface = "30439,30447,32273";//lets pretend this is the textbox value entered by the user
            Dictionary<string, string> DictionaryOfResults = new Dictionary<string, string>();
            DictionaryOfResults = getTheDataLoopingThroughIDs(textThatWouldBeInATextBoxOnTheUserInterface);
        }
        private Dictionary<string, string> getTheDataLoopingThroughIDs(string incomingIDs)
        {
            Dictionary<string, string> incomingIDsTracker = new Dictionary<string, string>();//something to keep track of the incomingIDs
            foreach (string item in incomingIDs.Replace(" ", "").Split(','))
            {
                incomingIDsTracker.Add(item, null);//add all the ids(keys) to the dictionary, and give them a null value to start
            }
            //lets build the list of DBs we can connect to
            List<string> dbConnStrings = new List<string>();
            dbConnStrings.Add(@"Provider=SQLOLEDB;Server=Server\Schema;Database=dbName1;User Id=uid;Password=pwd;");
            dbConnStrings.Add(@"Provider=SQLOLEDB;Server=Server\Schema;Database=dbName2;User Id=uid;Password=pwd;");
            int TrackMyPositionInTheList = 0;//keep track of how many DBs you connected to
            while (incomingIDsTracker.ContainsValue(null) && TrackMyPositionInTheList < dbConnStrings.Count)//while there are values we haven't found yet, and while there are still DBs to connect to
            {
                using (OleDbConnection currentConnection = new OleDbConnection(dbConnStrings[TrackMyPositionInTheList]))//look into the DB determined by the PositionTracker
                {
                    Dictionary<string, string> tempdict = new Dictionary<string, string>();
                    tempdict = incomingIDsTracker.Where(p => p.Value == null).ToDictionary(p => p.Key, p => p.Value);//make a temp dictionary of only the keys with null values
                    string idstolookfor = string.Join(",", tempdict.Keys);//make that into a comma separated list that we can use in our sql query
                    string sqlQuery = "select dialid, docid from dial where dialid in (" + idstolookfor + ")";
                    currentConnection.Open();
                    OleDbCommand command = new OleDbCommand(sqlQuery, currentConnection);
                    if (command.ExecuteScalar() != null)//if you found something
                    {
                        OleDbDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            incomingIDsTracker[reader["DialId"].ToString()] = reader["docid"].ToString();
                        }
                    }
                    TrackMyPositionInTheList++;//if you reach this, you haven't found what you were looking for. Lets increment the PositionTracker by 1 and look again.
                }
            }
            return incomingIDsTracker;
        }
