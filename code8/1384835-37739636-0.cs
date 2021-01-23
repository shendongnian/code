                       string code = CreateFunctionCode();
                        var syntaxTree = CSharpSyntaxTree.ParseText(code);
                        MetadataReference[] references = new MetadataReference[]
                        {
                            MetadataReference.CreateFromFile(typeof(object).GetTypeInfo().Assembly.Location),
                            MetadataReference.CreateFromFile(typeof(Hashtable).GetTypeInfo().Assembly.Location)
                        }; 
                         var compilation = CSharpCompilation.Create("Function.dll",
                            syntaxTrees: new[] { syntaxTree },
                            references: references,
                            options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
                        StringBuilder message = new StringBuilder();
                        using (var ms = new MemoryStream())
                        {
                            EmitResult result = compilation.Emit(ms);
                            if (!result.Success)
                            {
                                IEnumerable<Diagnostic> failures = result.Diagnostics.Where(diagnostic =>
                                    diagnostic.IsWarningAsError ||
                                    diagnostic.Severity == DiagnosticSeverity.Error);
                                foreach (Diagnostic diagnostic in failures)
                                {
                                    message.AppendFormat("{0}: {1}", diagnostic.Id, diagnostic.GetMessage());
                                }
                                return new ReturnValue<MethodInfo>(false, "The following compile errors were encountered: " + message.ToString(), null);
                            }
                            else
                            {
                                
                                ms.Seek(0, SeekOrigin.Begin);
     #if NET451
                                Assembly assembly = Assembly.Load(ms.ToArray());
     #else
                                AssemblyLoadContext context = AssemblyLoadContext.Default;
                                Assembly assembly = context.LoadFromStream(ms);
     #endif
                                Type mappingFunction = assembly.GetType("Program");
                                _functionMethod = mappingFunction.GetMethod("CustomFunction");
                                _resetMethod = mappingFunction.GetMethod("Reset");
                            }
                        }
