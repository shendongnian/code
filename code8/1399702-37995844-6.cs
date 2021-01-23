    public static async Task<ObservableCollection<T>> GetStatuses<T, TContainer>(
        Expression<Func<TContainer, T>> viewModelProjection, 
        Func<MyDataService, Task<IEnumerable<T>>> retrieveStatusesAction)
        where T : IStatusViewModel, new()
    {
        var result = new ObservableCollection<T>();
        var blank = new T
        {
            StatusId = -1,
            Status = null,
            Description = null,
            IsActive = false,
            CreatedDate = DateTime.Now
        };
        result.Add(blank);
        var dataService = new MyDataService();
        foreach (var c in await retrieveStatusesAction())
            result.Add(c);
        var vmStatus = result.SingleOrDefault(c => c.StatusId.Equals(-1));
        var vm = (PropertyInfo)((MemberExpression)selector.Body).Member;
        vm.SetValue(customer, vmStatus, null);
        
        return result;
    }
