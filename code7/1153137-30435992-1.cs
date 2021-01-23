	if (changes != null)
	{
		foreach (DataTable table in changes.Tables)
		{
			try
			{
				adapter.Update(table);
				Console.WriteLine("Changes Done");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				continue;
			}
		}
	}
