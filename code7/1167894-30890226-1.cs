    bool isGui(Assembly exeAsm) {
       foreach (var asm in exeAsm.GetReferencedAssemblies()) {
           if (asm.FullName.Contains("System.Windows"))
              return true;
       }
       return false;
    }
