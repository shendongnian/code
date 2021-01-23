     // set the assembly location, namespace, and string name of desired type
     var assemblyLocation = Assembly.GetExecutingAssembly().Location;
     var namespaceToType = "Namespace.Of.Type";
     var desiredType = "C<int>";
     // write some code using above parameters
     var template = "using {0};\nusing System;\npublic class Snippet {{\n\tpublic static Type main() {{\n\t\treturn typeof({1});\n\t}}\n}}";
     var code = string.Format(template, namespaceToType, desiredType);
     
     // compile code in memory, then return value via reflection
     var provider = CodeDomProvider.CreateProvider("CSharp");
     var parameters = new CompilerParameters();
     parameters.GenerateExecutable = false;
     parameters.GenerateInMemory = true;
     parameters.ReferencedAssemblies.Add(assemblyLocation);
     var results = provider.CompileAssemblyFromSource(parameters, code);
     return mytype = results.CompiledAssembly.GetType("Snippet").GetMethod("main").Invoke(null, null) as Type;
