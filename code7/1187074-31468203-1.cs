    //Method Call:
    Dictionary<int, System.Type> attributions = new Dictionary<int, System.Type>(){{12, typeof[Lunch]}};
    Dispatcher(attributions);
    //Dispatcher
    public void Dispatcher(IDictionary<int, System.Type> dictionary) {
        int hour = SomeHour()
        // Instantiate object
        var obj = Activator.CreateInstance(attributions[hour]);
        //Build args
        var args = new object[]{
            new object(),
        };
        
        // Invoke method
        type.InvokeMember("ExecuteTask", System.Reflection.BindingFlags.Public, null, obj, args);
    }
