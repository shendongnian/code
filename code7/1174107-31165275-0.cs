        public string CompileCode()
        {
            var provider = new CSharpCodeProvider();
            var outputPath = Path.Combine(Path.GetDirectoryName(_path), "temp.dll");
            var compilerparams = new CompilerParameters(
                new[]
                {
                    @"D:\path\to\referenced\dll",
                    @"D:\path\to\referenced\dll2"
                }, outputPath);
            CompilerResults results = provider.CompileAssemblyFromFile(compilerparams, _path);
            var i = results.PathToAssembly;
            if (!results.Errors.HasErrors)
                return i;
            var errors = new StringBuilder("Compiler Errors :\r\n");
            foreach (CompilerError error in results.Errors)
            {
                errors.AppendFormat("Line {0},{1}\t: {2}\n",
                    error.Line, error.Column, error.ErrorText);
            }
            throw new Exception(errors.ToString());
        }
