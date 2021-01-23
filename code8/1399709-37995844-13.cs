    public static async Task<ObservableCollection<T>> GetStatuses<T>(
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
        foreach (var c in await retrieveStatusesAction(dataService))
            result.Add(c);
        // TODO Implement Expression<Func<TSource, TResult>> projection for assigning to VM
        StatusVm = result.SingleOrDefault(c => c.StatusId.Equals(-1));
        
        return result;
    }
