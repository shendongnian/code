    private ScriptEngine pyengine;
    private ScriptingEngine()
    {
        Dictionary<string, object> options = new Dictionary<string, object>();
        options["Debug"] = true;
        pyengine = Python.CreateEngine(options);
        var builtinscope = Python.GetBuiltinModule(pyengine);
        builtinscope.SetVariable("__import__", new ImportDelegate(ImportOverride));
    }
