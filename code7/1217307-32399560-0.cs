    namespace Validator {
        public class AllTests {
            [Suite]
            public static IEnumerable Suite {
                get {
                    var directory = @"[ImplementationAssembliesPath]";
                    var suite = new ArrayList();
                    
                    // GetInstances is a method responsible for loading the
                    // assemblys and instantiating the implementations to be tested.
                    foreach (var instance in GetInstances(directory)) {
                        suite.Add(GetResolvedTest(instance));
                    }
                    return suite;
                }
            }
            
            // This part is crucial - this is where I get to inject the 
            // implementations to the test.
            private static Object GetResolvedTest(ICalculator instance) {
                return new CalculatorTests {Calculator = instance};
            }
            [...]
    }
