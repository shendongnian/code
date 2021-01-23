	try
	{
		var result = cmd.ExecuteScalar();
		if (result != null)
		{
			maxID = Convert.ToInt32(result);
		}
		else
		{
			maxID = 0;
		}
	}
	catch(Exception e)
	{
		MessageBox.Show(e.ToString());
	}
