            var host = new CustomCmdLineHost();
            host.TemplateFileValue = "ExtDll.tt";
            Engine engine = new Engine();
            string input = File.ReadAllText("ExtDll.tt");
            string source = engine.ProcessTemplate(input, host);
            if (host.Errors.HasErrors)
            {
                var errorString = String.Join("\n", host.Errors.Cast<CompilerError>().Select(error => String.Format("Error ({0}): {1}", error.ErrorNumber, error.ErrorText)));
                throw new InvalidOperationException(errorString);            
            }
            CSharpCodeProvider provider = new CSharpCodeProvider();
    ... rest of the code as before
