    .Do(_ => WaitForDatabaseUp())
    public async Task WaitForDatabaseUp()
    {
        //If IsSubscribed continue execution
        if(IsSubscribed) return;
        //Else wait until IsSubscribed == true
        await this.ObservableForProperty(x => x.IsSubscribed, skipInitial = false)
                           .Value()
                           .Where(isSubscribed => isSubscribed)
                           .Take(1);
    }
