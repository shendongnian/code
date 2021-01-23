    var engine = Python.CreateEngine();
    dynamic clr = engine.Runtime.GetClrModule();
    clr.AddReference("IronPython.StdLib");
    // load assembly into engine
    var assembly = Assembly.LoadFrom("IronPython.StdLib.dll");
    engine.Runtime.LoadAssembly(assembly); 
    var references = (IEnumerable<Assembly>)clr.References;
    Debug.Assert(references.Any(asm => asm.FullName.StartsWith("IronPython.StdLib"))); // ok
    
    var source = "import pydoc\npydoc.plain(pydoc.render_doc(str))";
    var result = engine.Execute<string>(source);
    Debug.Assert(result.StartsWith("Python Library Documentation")); // ok
    
    var engine2 = Python.CreateEngine();
    dynamic clr2 = engine2.Runtime.GetClrModule();
    clr2.AddReference("IronPython.StdLib");
    // load assembly into engine2
    engine2.Runtime.LoadAssembly(assembly); 
    var references2 = (IEnumerable<Assembly>)clr.References;
    Debug.Assert(references2.Any(asm => asm.FullName.StartsWith("IronPython.StdLib"))); // does not fail
    
    result = engine.Execute<string>(source); // does not throw any more
    Debug.Assert(result.StartsWith("Python Library Documentation"));
