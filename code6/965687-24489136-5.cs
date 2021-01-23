cs
using IronPython.Hosting; 
using Microsoft.Scripting.Hosting; //provides scripting abilities comparable to batch files
using System.IO;
using System;
using System.Text;
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
Output:
    returned: 42
    captured out:
    2.7.5b2 (IronPython 2.7.5b2 (2.7.5.0) on .NET 2.0.50727.5477 (64-bit))
    captured err:
    this goes to stderr
