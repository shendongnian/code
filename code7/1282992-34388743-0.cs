    private static object RunCSharpCode(string CSharpCode, bool ShowErrors, string StringParameter)
    {
        try
        {
            #region Encapsulate Code into a single Method
            string Code =
                "using System;" + Environment.NewLine +
                "using System.Windows.Forms;" + Environment.NewLine +
                "using System.IO;" + Environment.NewLine +
                "using System.Text;" + Environment.NewLine +
                "using System.Collections;" + Environment.NewLine +
                "using System.Data.SqlClient;" + Environment.NewLine +
                "using System.Data;" + Environment.NewLine +
                "using System.Linq;" + Environment.NewLine +
                "using System.ComponentModel;" + Environment.NewLine +
                "using System.Diagnostics;" + Environment.NewLine +
                "using System.Drawing;" + Environment.NewLine +
                "using System.Runtime.Serialization;" + Environment.NewLine +
                "using System.Runtime.Serialization.Formatters.Binary;" + Environment.NewLine +
                "using System.Xml;" + Environment.NewLine +
                "using System.Reflection;" + Environment.NewLine +
    
                "public class UserClass" + Environment.NewLine +
                "{" + Environment.NewLine +
                "public object UserMethod( string StringParameter )" + Environment.NewLine +
                "{" + Environment.NewLine +
                "object Result = null;" + Environment.NewLine +
                Environment.NewLine +
                Environment.NewLine +
    
                CSharpCode +
    
                Environment.NewLine +
                Environment.NewLine +
                "return Result;" + Environment.NewLine +
                "}" + Environment.NewLine +
                "}";
            #endregion
    
            #region Compile the Dll to Memory
    
            #region Make Reference List
            Assembly[] FullAssemblyList = AppDomain.CurrentDomain.GetAssemblies();
    
            System.Collections.Specialized.StringCollection ReferencedAssemblies_sc = new System.Collections.Specialized.StringCollection();
    
            foreach (Assembly ThisAssebly in FullAssemblyList)
            {
                try
                {
                    if (ThisAssebly is System.Reflection.Emit.AssemblyBuilder)
                    {
                        // Skip dynamic assemblies
                        continue;
                    }
    
                    ReferencedAssemblies_sc.Add(ThisAssebly.Location);
                }
                catch (NotSupportedException)
                {
                    // Skip other dynamic assemblies
                    continue;
                }
            }
    
            string[] ReferencedAssemblies = new string[ReferencedAssemblies_sc.Count];
            ReferencedAssemblies_sc.CopyTo(ReferencedAssemblies, 0);
            #endregion
    
            Microsoft.CSharp.CSharpCodeProvider codeProvider = new Microsoft.CSharp.CSharpCodeProvider();
            System.CodeDom.Compiler.ICodeCompiler CSharpCompiler = codeProvider.CreateCompiler();
            System.CodeDom.Compiler.CompilerParameters parameters = new System.CodeDom.Compiler.CompilerParameters(ReferencedAssemblies);
            parameters.GenerateExecutable = false;
            parameters.GenerateInMemory = true;
            parameters.IncludeDebugInformation = false;
            parameters.OutputAssembly = "ScreenFunction";
    
            System.CodeDom.Compiler.CompilerResults CompileResult = CSharpCompiler.CompileAssemblyFromSource(parameters, Code);
            #endregion
    
            if (CompileResult.Errors.HasErrors == false)
            { // Successful Compile
                #region Run "UserMethod" from "UserClass"
                System.Type UserClass = CompileResult.CompiledAssembly.GetType("UserClass");
                object Instance = Activator.CreateInstance(UserClass, false);
                return UserClass.GetMethod("UserMethod").Invoke(Instance, new object[] { StringParameter });
                #endregion
            }
            else // Failed Compile
            {
                if (ShowErrors)
                {
                    #region Show Errors
                    StringBuilder ErrorText = new StringBuilder();
    
                    foreach (System.CodeDom.Compiler.CompilerError Error in CompileResult.Errors)
                    {
                        ErrorText.Append("Line " + (Error.Line - 1) +
                            " (" + Error.ErrorText + ")" +
                            Environment.NewLine);
                    }
    
                    MessageBox.Show(ErrorText.ToString());
                    #endregion
    
                }
            }
        }
        catch (Exception E)
        {
            if (ShowErrors)
                MessageBox.Show(E.ToString());
        }
    
        return null;
    }
