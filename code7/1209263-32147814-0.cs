		foreach (string x in newUsers)
		{
			Console.WriteLine("looking for user {0}", x);
			searcher.Filter = string.Format("(&(objectCategory=person)(anr={0}))", x);
			var result = searcher.FindOne();
			if (result == null)
			{
				userList.Add(String.Format("user {0} not found!", x));
			}
			else 
			{
				userList.Add(string.Format("{0} {1}", result.Properties["DisplayName"][0].ToString(), result.Properties["Company"][0].ToString()));
			}
			search.Dispose();
		}
