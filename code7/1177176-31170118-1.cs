    public class Oracle {
	public void Insert(List<string> oracleArguments) {
		string oracleConnectionString = "User Id=" + oracleArguments[0] + "; Password=" + oracleArguments[1] + "; Data Source=" + oracleArguments[2];
		using (OracleConnection oracleConnection = new OracleConnection(oracleConnectionString)) {
			//do something
		}
	}
    }
