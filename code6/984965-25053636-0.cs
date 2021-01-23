    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Tuple<string, string>> results = new List<Tuple<string, string>>();
                bool validator = true;
    
                TryCatch(Pass, results, ref validator);
                TryCatch(Fail, results, ref validator);
            }
    
            private static void Pass()
            {
            }
    
            private static void Fail()
            {
                throw new Exception("oops");
            }
    
            private static void TryCatch(Action action, List<Tuple<string, string>> results, ref bool validator)
            {
                try
                {
                    action();
                    results.Add(Tuple.Create(action.Method.DeclaringType.FullName + "." + action.Method.Name, "Passed !"));
                }
                catch (Exception ex)
                {
                    validator = false;
                    results.Add(Tuple.Create(action.Method.DeclaringType.FullName + "." + action.Method.Name, "Failed : " + ex.Message));
                }
            }
        }
    }
