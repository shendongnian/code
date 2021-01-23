        class Program
        {
            static void Main(string[] args)
            {
                TestScript();
            }
    
            private static async void TestScript()
            {
                // Code snippet: a class with one string-property.
                string codeContent = @" using System;
    
                                        public class ScriptedClass
                                        {
                                            public string HelloWorld { get; set; }
    
                                            public ScriptedClass()
                                            {
                                                HelloWorld = ""Hello Roslyn!"";
                                            }
                                        }
    
                                        new ScriptedClass().HelloWorld";
    
                // Instanciate CSharpScriptEngine
                var engine = new CSharpScriptEngine();
                // Execute code and return string property
                var scriptingState = await engine.ExecuteAsync(codeContent);
    
                // Print return value from CSharpScript
                Console.WriteLine("Returned from CSharpScript: {0}", scriptingState.ReturnValue);
    
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
        }
