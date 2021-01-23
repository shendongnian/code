    private object[] SortArrayOfObjects<T>(object[] dataSource, string propertyName, string sortDirection)
        {
            string sortExpression = string.Format("{0} {1}", propertyName, sortDirection);
            // sortExpression will be something like "FirstName DESC".
    
            // OrderBy method takes expression as string like "FirstName DESC".
            // OrderBy method exists in "System.Linq.Dynamic" dll.
            // Download it from www.nuget.org/packages/System.Linq.Dynamic/
            object[] arrSortedObjects = dataSource.Cast<T>().OrderBy(sortExpression).Cast<object>().ToArray();
    
            return arrSortedObjects;
        }
    }
    
    // Use it like:       | You pass the type, so no need for hardcoding it, and it should work for all types.
    SortArrayOfObjects<EmployeeInfo>(object[] dataSource, string propertyName, string sortDirection);
