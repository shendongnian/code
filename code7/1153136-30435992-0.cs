	if (changes != null)
	{
		try
		{
			adapter.Update(changes);
			Console.WriteLine("Changes Done");
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
		}
	}
