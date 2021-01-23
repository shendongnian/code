    var stackTrace = new StackTrace();
    var frames = stackTrace.GetFrames();
    foreach(var frame in frames)
    {
       var methodDescription = frame.GetMethod();
       Console.WriteLine(methodDescription.Name);
    }
