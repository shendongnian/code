	List<string> readList = new List<string>();
	List<string> uriList = new List<string>();
	using (var connection = new SqlConnection(connectionString))
	{
		connection.Open();
		DateTime now = DateTime.Now;
		now = now.AddMilliseconds(-now.Millisecond);
		var command = new SqlCommand("SELECT ImageName FROM Images WHERE NotifyDate = @todayDate", connection);
		var paramDate = new SqlParameter("@todayDate", now);
		command.Parameters.Add(paramDate);
		string readerTest = "";
		string uriReadString = "";
		using (SqlDataReader reader = command.ExecuteReader())
		{
			while (reader.Read())
			{
				readerTest = reader[0].ToString();
				System.IO.File.WriteAllText(@"C:\Users\Nathan\Documents\Visual Studio 2013\Projects\MVCImageUpload\uploads\GetIDNow.txt", readerTest);
				readList.Add(readerTest);
			}
		}
		using (SqlDataReader readerUri = commandUri.ExecuteReader())
		{
			while (readerUri.Read())
			{
				uriReadString = readerUri[0].ToString();
				System.IO.File.WriteAllText(@"C:\Users\Nathan\Documents\Visual Studio 2013\Projects\MVCImageUpload\uploads\GetUriNow.txt", uriReadString);
				uriList.Add(uriReadString);
			}
		}
		
		for(int i = 0; i < readList.Count; i++)
			SendPushNotification(uriList[i], readList[i]);
