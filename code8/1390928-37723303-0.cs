    static void Main(string[] args)
    {
        ScriptEngine engine = Python.CreateEngine();
        ScriptSource source = engine.CreateScriptSourceFromFile("Calculator.py");
        ScriptScope scope = engine.CreateScope();
        source.Execute(scope);
        dynamic class_object = scope.GetVariable("Calculator");
        dynamic class_instance = class_object();
        int result = Dynamic.InvokeMember(class_instance, "add", 4, 5);
    }
