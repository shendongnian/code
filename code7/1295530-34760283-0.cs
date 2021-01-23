    using System.CodeDom.Compiler;
    using Microsoft.CSharp;
    using System.Reflection;
    ...
    static void Main()
    {
        double? result = Calculate("12 + 43 * (12 / 2)");
    }
    
    static double? Calculate(string formula)
    {
        double result;
        try
        {
            CompilerParameters compilerParameters = new CompilerParameters
            {
                GenerateInMemory = true, 
                TreatWarningsAsErrors = false, 
                GenerateExecutable = false, 
            };
    
            string[] referencedAssemblies = { "System.dll" };
            compilerParameters.ReferencedAssemblies.AddRange(referencedAssemblies);
    
            const string codeTemplate = "using System;public class Dynamic {{static public double Calculate(){{return {0};}}}}";
            string code = string.Format(codeTemplate, formula);
    
            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerResults compilerResults = provider.CompileAssemblyFromSource(compilerParameters, new string[]{code});
            if (compilerResults.Errors.HasErrors)
                throw new Exception();
    
            Module module = compilerResults.CompiledAssembly.GetModules()[0];
            Type type = module.GetType("Dynamic");
            MethodInfo method = type.GetMethod("Calculate");
    
            result = (double)(method.Invoke(null, null));
        }
        catch (Exception)
        {
            return null;
        }
    
        return result;
    }
