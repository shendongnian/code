    // read the data
    dynamic RS = CMD.ExecuteReader(System.Data.CommandBehavior.Default);
    // store objects in list
    this.DBMSCommandCodes.Add(DBMSCommandCounter);
    this.DBMSCommands.Add(CMD);
    this.DBMSResultSets.Add(RS);
