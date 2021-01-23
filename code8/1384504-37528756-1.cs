    static void Compile(DynamicActivity dynamicActivity)
            {
                TextExpressionCompilerSettings settings = new TextExpressionCompilerSettings
                {
                    Activity = dynamicActivity,
                    Language = "C#",
                    ActivityName = dynamicActivity.Name.Split('.').Last() + "_CompiledExpressionRoot",
                    ActivityNamespace = string.Join(".", dynamicActivity.Name.Split('.').Reverse().Skip(1).Reverse()),
                    RootNamespace = null,
                    GenerateAsPartialClass = false,
                    AlwaysGenerateSource = true,
                };
    
                TextExpressionCompilerResults results =
                    new TextExpressionCompiler(settings).Compile();
                if (results.HasErrors)
                {
                    throw new Exception("Compilation failed.");
                }
    
                ICompiledExpressionRoot compiledExpressionRoot =
                    Activator.CreateInstance(results.ResultType,
                        new object[] { dynamicActivity }) as ICompiledExpressionRoot;
                CompiledExpressionInvoker.SetCompiledExpressionRootForImplementation(
                    dynamicActivity, compiledExpressionRoot);
            }
