    public async Task<ObservableCollection<EmployeeViewModel>> 
        SearchEmployeesAsync(string selectedColumn, string searchValue)
    {
      var paramEmployee = Expression.Parameter(typeof(Employee), "e");
      var comparison = Expression.Lambda<Func<Employee, bool>>(
        Expression.Equal(
          Expression.Property(paramEmployee, selectedColumn),
          Expression.Constant(searchValue)),
          paramEmployee).Compile();
      using (var context = new MyEntities())
      {
        var query = (from e in context.Employees
                     .Where(comparison)
                     select new EmployeeViewModel
                     {
                         // Various EF model properties...
                     });
        var data = await query.ToListAsync();
        return new ObservableCollection<EmployeeViewModel>(data);
      }
    }
    public async Task SearchEmployeesAsync()
    {
      var dataService = new EmployeeDataService();
      IsSearching = true;
      try
      {
        SearchResults = await dataService.SearchEmployeesAsync(SelectedColumn, SearchValue);
      }
      finally
      {
        IsSearching = false;
      }
    }
