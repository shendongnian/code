    dynamic script = CSScript.Evaluator
                             .LoadCode(@"using System;
                                         using Your.Custom.Relevant.Namespace;
                                         public class Executer
                                         {
                                             public object Execute()
                                             {
                                                 return SomeStaticClass.array[123];
                                             }
                                         }");
    int result = script.Execute();
    //shorter way
    int a = (int)CSScript.Evaluator.Evaluate("some.namespace.SomeStaticClass.array[123]");
