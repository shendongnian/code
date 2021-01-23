    //Method Call:
    Dispatcher(hourAndTaskDictionary, typeof(MyTypeWithMethodsIWantToCall));
    //Dispatcher
    public void Dispatcher(IDictionary<string, string> dictionary, System.Type type) {
        var obj = Activator.CreateInstance(type);
        string task;
        // Get method name to call
        dictionary.TryGetValue("1200", task);
        //Build args
        var args = new object[]{
            new object(),
        };
        
        // Invoke method
        type.InvokeMember(task, System.Reflection.BindingFlags.Public, null, obj, args);
    }
