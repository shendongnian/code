    public static Operations op = new Operations();
    public List<Action<ExampleClass>> opList = new List<Action<ExampleClass>>();
    
    oplist.AddRange(op
        .GetType()
        .GetMethods()
        .Select(methodInfo => (Action<ExampleClass>)Delegate.CreateDelegate(typeof(Action<ExampleClass>), op, methodInfo)));
