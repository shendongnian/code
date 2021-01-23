     public MainMethod()
     {
        Action<string> writerAction = (message) => Console.WriteLine(message); 
        writerAction("Execute One");
        writerAction("Execute Two");
        writerAction("Execute Three");
     }
    
