    namespace MyTestRunner
    {
        using System;
        using System.Linq;
        using Xunit;        
        public class Program
	    {
		    public static int Main(string[] args)
            {
                var testAssembly = TestAssemblyBuilder.Build(
                    new ExecutorWrapper(args[0], null, false));
                var tests = testAssembly.EnumerateTestMethods(x =>  x
                    .DisplayName
                    .ToLowerInvariant();
                var testMethods = (args.Length > 1 && !string.IsNullOrEmpty(args[1])
                    ? tests.Contains(args[1].ToLowerInvariant())).ToList()
                    : tests.ToList();
                if (testMethods.Count == 0)
				    return 0;
                var runnerCallback = new TestMethodRunnerCallback();
                testAssembly.Run(testMethods, runnerCallback);
                return runnerCallback.FailedCount;
            }
            public class TestMethodRunnerCallback : ITestMethodRunnerCallback
            {
                public int FailedCount { get; private set; }
                public void AssemblyFinished(TestAssembly testAssembly, int total, int failed, int skipped, double time)
                {
                    FailedCount = failed;
                }
                public void AssemblyStart(TestAssembly testAssembly)
                {
                }
                public bool ClassFailed(TestClass testClass, string exceptionType, string message, string stackTrace)
                {
                    return true;
                }
                public void ExceptionThrown(TestAssembly testAssembly, Exception exception)
                {
                }
                public bool TestFinished(TestMethod testMethod)
                {
                    return true;
                }
                public bool TestStart(TestMethod testMethod)
                {
                    return true;
                }
            }
        }
    }
