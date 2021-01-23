    IDictionary<string, object> options = new Dictionary<string, object>();
    
    options.Add("PrivateBinding", true);
    
    ScriptEngine engine = IronPython.Hosting.Python.CreateEngine(options);
