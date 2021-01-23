    // use a variable to store the path.
    private string logFileNameAndPath;
    public void ProcessData(string StoredProcedure, int StartDate, int EndDate, string Directory, string LogFileNameAndPath)
    {
       // Store the parameter that was passed in as the variable.
       this.logFileNameAndPath = LogFileNameAndPath;
       /* Do query setup work here*/
       sqlConnection.InfoMessage += new SqlInfoMessageEventHandler(OnInfoMessage);
       sqlCommand.ExecuteNonQuery();
    }
    public void OnInfoMessage(object sender, SqlInfoMessageEventArgs args)
    {
        foreach (SqlError err in args.Errors)
        {
            // Use the variable to indicate where to log to.
            File.AppendAllText(this.logFileNameAndPath, err.Message);
        }
    }
