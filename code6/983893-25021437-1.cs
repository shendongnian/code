    public class Interface 
    {
         private readonly Assembly underlyingAssembly;
         publiic Interface(Assembly asm)
         {
            this.underlyingAssembly = asm;
         }
         
         // other methods
    }
    
    Assembly someAsm = MyCompilerResults.CompiledAssembly();
    Interface interface = new Interface(someAsm);
