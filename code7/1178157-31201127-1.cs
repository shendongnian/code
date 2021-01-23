    public async void InsertEmployee(Employee e)
    {
        SQLiteAsyncConnection conn = new SQLiteAsyncConnection("Employee.sqlite");
        conn.InsertAsync(e);
        await FetchEmployees();
     }
    public async Task FetchEmployeesAsync()
    {
        SQLiteAsyncConnection conn = new SQLiteAsyncConnection("Employee.sqlite");
        employees = await conn.Table<Employee>().ToListAsync();
        DisplayList();
    }
