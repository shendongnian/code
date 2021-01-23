    System.Reflection.Assembly ass = System.Reflection.Assembly.GetEntryAssembly();
    foreach (System.Reflection.TypeInfo ti in ass.DefinedTypes)
    {
        if (ti.ImplementedInterfaces.Contains(typeof(yourInterface)))
        {
            ass.CreateInstance(ti.FullName) as yourInterface;
        }  
    }
