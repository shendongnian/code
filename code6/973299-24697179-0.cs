	static void Main(string[] args)
	{
		string r = "Test";
		using (var adapter = new SqlDataAdapter(r, new SqlConnection("")))
		{
			r = "Test2";
			Console.WriteLine(adapter.SelectCommand.CommandText);
		}
	   
	}
	
