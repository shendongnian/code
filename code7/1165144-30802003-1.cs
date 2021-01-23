    using (var db = new SQLite.SQLiteConnection(connection string))
    {
    	string query = "select a.name AS Name, b.LoginTime AS LoginTime from user_tbl a inner join user_login_history b on a.id=b.UserID";
	    SQLiteCommand cmd = new SQLiteCommand(db);
	    cmd.CommandText = query.ToString();
	    var result = cmd.ExecuteQuery<YourModelClass>();
    }
