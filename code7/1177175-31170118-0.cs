    public static void Main(string[] args) {
	string oracleUser, oraclePassword, oracleDatabase;
	List<string> oracleArguments = new List<string>();
	//0 = oracleUser
	//1 = oraclePassword
	//2 = oracleDatabase
	//3 = oracleCommandText
	//4+ = oracleCommand.Parameters
	l_orauser = "schema1";
	l_orapass = "schema1pass";
	l_oradb = "db1";
	oracleArguments.Add(l_orauser);
	oracleArguments.Add(l_orapass);
	oracleArguments.Add(l_oradb);
	Oracle testOracle = new Oracle();
	testOracle.Insert(oracleArguments);
    }
