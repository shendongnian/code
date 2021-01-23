	string[] sql = line.Split(' ');
	
	dynamic id = sql[0];
	dynamic username = sql[1];
	dynamic email = sql[2];
	dynamic password = sql.Length > 4 ? sql[3] : null;
	dynamic plainPassword = sql.Length == 5 ? sql[4] : null;
