    public async Task SearchEmployeesAsync()
    {
      var dataService = new EmployeeDataService();
      var selectedColumn = SelectedColumn;
      var searchValue = searchValue;
      IsSearching = true;
      try
      {
        SearchResults = await Task.Run(() => dataService.SearchEmployees(selectedColumn, searchValue));
      }
      finally
      {
        IsSearching = false;
      }
    }
