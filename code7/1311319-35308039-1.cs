        var result = new ServiceReturnInformation<Employee>();
        try
		{
			// Do something
			result.DataContext = GetEmployee();
        }
        catch (Exception ex)
        {
            result.DataContext = null;
            result.Errors.Add(ex.Message);
        }
		return result;
    
