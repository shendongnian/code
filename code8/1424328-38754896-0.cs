    WeakReference(weakRef = new WeakReference(results.CompiledAssembly.CreateInstance("Code.Class"));
    MethodInfo mi = weakRef.Target.GetType().GetMethod("Main");
    mi.Invoke(o, null);
    
    // Wait until the application exists AND the Garbage Collector cleans it up
    while (weakRef.IsAlive)
    {
         Thread.Sleep(100);
    }
