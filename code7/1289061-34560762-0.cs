    dynamic script = CSScript.Evaluator
                             .LoadCode(@"using System;
                                         using Your.Custom.Relevant.Namespace;
                                         public class Executer
                                         {
                                             public object Execute()
                                             {
                                                 return SomeStaticClass[123];
                                             }
                                         }");
            int result = script.Execute();
