    using System;
    using System.Collections.Generic;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using Microsoft.CSharp;
    using System.Reflection;
    namespace dllTest {
	public class AssemblyGeneration {
		
		public static Assembly generateAssemblyFromCode(string code, string assemblyFilename) {
			CSharpCodeProvider codeProvider = new CSharpCodeProvider();
			System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
			parameters.GenerateExecutable = false;
			parameters.OutputAssembly = assemblyFilename + ".dll";
			CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, code);
			
			Assembly assembly = null;
		    if (!results.Errors.HasErrors) {
		        assembly = results.CompiledAssembly;
				return assembly;
		    }
			else {
				return null;
			}
		}
	}
    }
