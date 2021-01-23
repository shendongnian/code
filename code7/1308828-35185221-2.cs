    .SelectMany(logEvent => WaitForDatabaseUp(item))
    
    public async Task<T> WaitForDatabaseUp<T>(T item)
    {
        //If IsSubscribed continue execution
        if(IsSubscribed) return item;
        //Else wait until IsSubscribed == true
        await this.ObservableForProperty(x => x.IsSubscribed, skipInitial: false)
                           .Value()
                           .Where(isSubscribed => isSubscribed)
                           .Take(1);
        return item;
    }
