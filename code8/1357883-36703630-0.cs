    string code = @"
        using System;
    
        namespace First
        {
            public class Program
            {
                public static void Main()
                {
                " +
                    "Console.WriteLine(\"Hello, world!\");"
                    + @"
                }
            }
        }
    "; //Assume this is the code the client gave you
    CSharpCodeProvider provider = new CSharpCodeProvider();
    CompilerParameters parameters = new CompilerParameters();
    
    parameters.GenerateInMemory = true; //You can add references to libraries using parameters.ReferencedAssemblies.Add(string - name of the assembly).
    
    CompilerResults results = provider.CompileAssemblyFromSource(parameters, code); //Compiling the string to an assembly
    
    if (results.Errors.HasErrors)
    {
        StringBuilder sb = new StringBuilder();
    
        foreach (CompilerError error in results.Errors)
        {
            sb.AppendLine(String.Format("Error ({0}): {1}", error.ErrorNumber, error.ErrorText));
        }
    
        throw new InvalidOperationException(sb.ToString());
    } //Error checking
    
    Assembly assembly = results.CompiledAssembly;
    Type program = assembly.GetType("First.Program"); //Getting the class object
    MethodInfo main = program.GetMethod("Main"); //Getting the main method to invoke
    
    main.Invoke(null, null); //Invoking the method. first null - because the method is static so there is no specific instance to run in, second null tells us there are no parameters.
