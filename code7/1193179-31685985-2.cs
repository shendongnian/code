    protected void searchButton_Click(object sender, EventArgs e)
	{
		CheckDates();
		if (string.IsNullOrEmpty(startDate.Text)) employeesSqlDataSource.SelectParameters["startDate"].DefaultValue = SqlDateTime.MinValue.ToString();
		if (string.IsNullOrEmpty(endDate.Text)) employeesSqlDataSource.SelectParameters["endDate"].DefaultValue = SqlDateTime.MaxValue.ToString();
		employeesSqlDataSource.DataBind();
    }
