                internal sealed class CSharpScriptEngine
                {
                    public async Task<ScriptState<object>> ExecuteAsync(string codeContent)
                    {
                        // Add references from calling assembly
                        ScriptOptions options = ScriptOptions.Default.AddReferences(Assembly.GetExecutingAssembly());
        
                        // Run codeContent with given options
                        return await CSharpScript.RunAsync(codeContent, options);
                    }
                }
