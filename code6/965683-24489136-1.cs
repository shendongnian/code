    var script = @"import sys
    def test(): 
        print sys.version
        print >> sys.stderr, 'not captured'
        return 42";
    var scriptEngine = Python.CreateEngine();
    var scriptScope = scriptEngine.CreateScope();
    scriptEngine.Execute(script, scriptScope);
    var testFn = scriptScope.GetVariable("test");
    var stream = new MemoryStream();
    scriptEngine.Runtime.IO.SetOutput(stream, Encoding.Default);
    scriptEngine.Operations.Invoke(testFn);
    Console.WriteLine("returned: {0}", scriptEngine.Operations.Invoke(testFn));
    Console.WriteLine("captured:\n{0}", Encoding.Default.GetString(stream.ToArray()));
