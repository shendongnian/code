    // Assumes that connection represents a SqlConnection object.
    connection.InfoMessage += new SqlInfoMessageEventHandler(OnInfoMessage);
    
    protected static void OnInfoMessage(object sender, SqlInfoMessageEventArgsargs) {
        foreach (SqlError err in args.Errors) {
            Console.WriteLine("The {0} has received a severity {1}, state {2} error number {3}\non line {4} of procedure {5} on server {6}:\n{7}",
              err.Source, err.Class, err.State, err.Number, err.LineNumber, err.Procedure, err.Server, err.Message);
        }
    }
