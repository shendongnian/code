    namespace TestRunner {
        using System;
        using NUnit.ConsoleRunner;
        internal class Program {
            private static void Main(String[] args) {
                var testDllPath = @"[TestAssemblyPath]/Validator.dll";
                var processArgument = @"/process=Separate";
                var domainArgument = @"/domain=Multiple";
                var runtimeArgument = @"/framework=4.5";
                var shadowArgument = @"/noshadow";
                var fixtureArgument = String.Format(@"/fixture={0}", "[Namespace].AllTests");
                Runner.Main(new[] {
                    testDllPath,
                    processArgument,
                    domainArgument,
                    runtimeArgument,
                    shadowArgument,
                    fixtureArgument
                });
                Console.ReadLine();
            }
        }
    }
