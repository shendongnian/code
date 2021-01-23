        AssemblyName[] referencedAssemblies = assm.GetReferencedAssemblies();
        foreach (var assmName in referencedAssemblies)
        {
          if (assmName.Name.StartsWith("System.Windows"))
           //bingo
        }
