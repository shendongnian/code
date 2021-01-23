	void Main()
	{
		var conStr = GetConnectionString(@"C:\Users\user\Desktop\myDatabase.mdb", null, null);
		CreateDb(conStr);
	}
	//[System.Security.SecuritySafeCritical]
	public void CreateDb(string connectionString) {
		Type adoxType = Type.GetTypeFromProgID("ADOX.Catalog");
		object o = Activator.CreateInstance(adoxType);
		o.GetType().InvokeMember("Create", BindingFlags.InvokeMethod, null, o, new object[] { connectionString });
		object connection = o.GetType().InvokeMember("ActiveConnection", BindingFlags.GetProperty, null, o, null);
		if(connection != null)
			connection.GetType().InvokeMember("Close", BindingFlags.InvokeMethod, null, connection, null);
	}
	public static string GetConnectionString(string database, string userid, string password) {
		return String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Mode=Share Deny None;data source={0};user id={1};{3}password={2};", 
		database, userid, password, string.IsNullOrEmpty(password) ? string.Empty : "Jet OLEDB:Database ");
	}
