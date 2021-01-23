    void SomeFunction<T>()
    {
        // ..............
        var returnObj = genericMethod.Invoke(_eventAggregator, null) as PubSubEvent<T>;
        returnObj?.Publish(data);
    }
    // call it like:
    SomeFunction<DataObject>();
