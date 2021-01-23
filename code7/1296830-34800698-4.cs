            private static async void TestScript()
            {
                // Read in script file
                string codeContent = File.ReadAllText(@"C:\Temp\CSharpScriptTest.cs");
    
                var engine = new CSharpScriptEngine();
                // Run script
                var scriptingState = await engine.ExecuteAsync(codeContent);
    
                Console.WriteLine("Returned from CSharpScript: {0}", scriptingState.ReturnValue);
    
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
