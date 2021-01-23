    using System;
    using System.Reflection;
    using NUnit.Common;
    using NUnitLite;
    namespace NetMQ.Tests
    {
        public static class Program
        {
            private static int Main(string[] args)
            {
                using (var writer = new ExtendedTextWrapper(Console.Out))
                {
                    return new AutoRun(Assembly.GetExecutingAssembly())
                        .Execute(args, writer, Console.In);
                }
            }
        }
    }
