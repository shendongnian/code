		if (!IsPostBack)
		{
			// Default the grid to the last 24 hours worth of data
			employeesSqlDataSource.SelectParameters["startDate"].DefaultValue = DateTime.Now.AddDays(-1).ToString();
			employeesSqlDataSource.SelectParameters["endDate"].DefaultValue = DateTime.Now.ToString();
            ...
            ...
        }
