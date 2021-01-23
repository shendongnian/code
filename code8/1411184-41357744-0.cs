    using (REngine engine = REngine.CreateInstance("RDotNet"))
                    {
                        // Initializes settings.
                        engine.Initialize();
        
        
                        var myAddFunc = engine.Evaluate(@"addFunc  <- function(a,b) {
                                                            a+b
                                                          }").AsFunction();
        
                        var sum = engine.Evaluate(@"addFunc(12,30)").AsNumeric();
        
                        engine.Evaluate("print(sum)");
                        Console.Write(sum[0].ToString());
                        Console.ReadKey();
                    }
