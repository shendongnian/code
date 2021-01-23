    using RDotNet;
    using System;
    
    namespace SimpleScriptingTest
    {
        class Program
        {
            static void Main(string[] args)
            {            
                REngine.SetEnvironmentVariables();
    
                REngine engine = REngine.GetInstance();
    
                engine.Initialize();
                var path = "C:\\\\Program Files\\\\R\\\\RWDir\\\\HelloWorldTest.R";
                engine.Evaluate("source('" + path + "')");
                Console.ReadLine();
            }
    
        }
    }
