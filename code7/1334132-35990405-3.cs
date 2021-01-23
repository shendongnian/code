    protected void Page_Load(object sender, EventArgs e)
    {
        RegisterAsyncTask(new PageAsyncTask(DoWorkAsync));
    }
    
    private async Task DoWorkAsync()
    {
        ActiveEmployeesDropDownList.DataSource = GetDataTableAsync(databaseConnection, new SqlCommand("select * from activeemployees"));
        ActiveEmployeesDropDownList.DataBind();
    }
