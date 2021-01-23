    string src = @"[DelimitedRecord(",")] [IgnoreEmptyLines()] private class ...";
    var compParms = new CompilerParameters
                {
                    GenerateExecutable = false,
                    GenerateInMemory = true
                };
    var csProvider = new CSharpCodeProvider();
                CompilerResults compilerResults = csProvider.CompileAssemblyFromSource(compParms, src);
