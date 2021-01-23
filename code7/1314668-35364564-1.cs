	public void InsertNewCar()
	{
		try
		{
			Car myCar = new Car();
			myCar.Insert();
		}
		catch (Exception ex)
		{
		if (ex is ApplicationException)
			alert("Something missing Msg");
		else /* This is the original exception */
			alert("Something wrong generic error");
	}
	public void Insert()
	{
		try
		{
			SqlHelper.ExecuteNonQuery(ConnString, CommandType.Text, sqlInsert);
		}
		catch (SqlException ex)
		{
			if (ex.Number == 515)
			{
				throw new ApplicationException("Missing something", ex);
			}
			else
			{
				throw ex;
			}
		}
	}
