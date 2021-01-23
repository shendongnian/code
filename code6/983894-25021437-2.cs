    public static class AsmExt
    {
         public static void SomeMethod(this Assembly asm)
         {
         }
    }
    
    Assembly someAsm = MyCompilerResults.CompiledAssembly();
    someAsm.SomeMethod();
