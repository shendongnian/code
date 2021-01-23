    [CompilerGenerated]
    internal class Closure<T>
    {
        public string Result {get; private set;}
    
        private readonly string _templatePath;
        private readonly T _data;
    
        public Closure(string templatePath, T data)
        {
          _templatePath = templatePath;
          _data = data;
        }
    
        public void DelegateMethod()
        {
          Result = Razor.Run(_data, _templatePath);
        }
    }
    
    public static string RenderTemplate<T>(string templatePath, T data)
    {
        Closure<T> closure = new Closure<T>(templatePath, data);   
        ExecuteRazorMethod(closure);
            
        return closure.Result;
    }
    
    private static void ExecuteRazorMethod<T>(Closure<T> closure)
    {
        try
        {
            closure.DelegateMethod();
        }
       .
       .
       .//irrelevant code
       .
    }
