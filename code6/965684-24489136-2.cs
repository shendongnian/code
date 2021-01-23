    var script = @"import sys
    def test(): 
        print sys.version
        print >> sys.stderr, 'this goes to stderr'
        return 42";
    var scriptEngine = Python.CreateEngine();
    var scriptScope = scriptEngine.CreateScope();
    scriptEngine.Execute(script, scriptScope);
    var testFn = scriptScope.GetVariable("test");
    var streamOut = new MemoryStream();
    var streamErr = new MemoryStream();
    scriptEngine.Runtime.IO.SetOutput(streamOut, Encoding.Default);
    scriptEngine.Runtime.IO.SetErrorOutput(streamErr, Encoding.Default);
    scriptEngine.Operations.Invoke(testFn);
    Console.WriteLine("returned: {0}", scriptEngine.Operations.Invoke(testFn));
    Console.WriteLine("captured out:\n{0}", Encoding.Default.GetString(streamOut.ToArray()));
    Console.WriteLine("captured err:\n{0}", Encoding.Default.GetString(streamErr.ToArray()));
