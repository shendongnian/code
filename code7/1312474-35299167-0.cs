    IEnumerable array = collection.Select(() => .....);
    foreach(var item in array)
    {
        this.CurrentDispatcher.Invoke(new Action(() =>
        {
            //...
            object a = item;
            //...
        }), DispatcherPriority.Input);
    }
