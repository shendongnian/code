    using System;
    using System.Diagnostics;
    using System.Linq.Expressions;
    namespace ExpressionTest
    {
        public interface IFoo
        {
            int Bar();
        }
        public sealed class FooImpl : IFoo
        {
            public int Bar()
            {
                return 0;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var foo = new FooImpl();
                var iFoo = (IFoo)foo;
                Func<int> directLambda = () => foo.Bar();
                Func<int> virtualLambda = () => iFoo.Bar();
                var directCall = CompileBar(foo, asInterfaceCall: false);
                var virtualCall = CompileBar(foo, asInterfaceCall: true);
                var iterationCount = 200000000;
                var sw = Stopwatch.StartNew();
                for (int i = 0; i < iterationCount; i++)
                    virtualCall();
                var elapsedMs = sw.ElapsedMilliseconds;
                Console.WriteLine($"Compiled Virtual Call: {elapsedMs} ms");
                sw.Restart();
                for (int i = 0; i < iterationCount; i++)
                    directCall();
                elapsedMs = sw.ElapsedMilliseconds;
                Console.WriteLine($"Compiled Direct Call: {elapsedMs} ms");
                sw.Restart();
                for (int i = 0; i < iterationCount; i++)
                    virtualLambda();
                elapsedMs = sw.ElapsedMilliseconds;
                Console.WriteLine($"Lambda Virtual Call: {elapsedMs} ms");
                sw.Restart();
                for (int i = 0; i < iterationCount; i++)
                    directLambda();
                elapsedMs = sw.ElapsedMilliseconds;
                Console.WriteLine($"Lambda Direct Call: {elapsedMs} ms");
                sw.Restart();
                for (int i = 0; i < iterationCount; i++)
                    iFoo.Bar();
                elapsedMs = sw.ElapsedMilliseconds;
                Console.WriteLine($"Virtual Call: {elapsedMs} ms");
                sw.Restart();
                for (int i = 0; i < iterationCount; i++)
                    foo.Bar();
                elapsedMs = sw.ElapsedMilliseconds;
                Console.WriteLine($"Direct Call: {elapsedMs} ms");
                // Reflection is very slow
                //sw.Restart();
                //for (int i = 0; i < iterationCount; i++) {
                //    int result = (int)iBarMethodInfo.Invoke(iFoo, null);
                //}
                //elapsedMs = sw.ElapsedMilliseconds;
                //Console.WriteLine($"Reflection Virtual Call: {elapsedMs} ms");
                //sw.Restart();
                //for (int i = 0; i < iterationCount; i++) {
                //    int result = (int)barMethodInfo.Invoke(foo, null);
                //}
                //elapsedMs = sw.ElapsedMilliseconds;
                //Console.WriteLine($"Reflection Direct Call: {elapsedMs} ms");            }
            static Func<int> CompileBar(IFoo foo, bool asInterfaceCall)
            {
                var fooType = asInterfaceCall ? typeof(IFoo) : foo.GetType();
                var methodInfo = fooType.GetMethod(nameof(IFoo.Bar));
                var instance = Expression.Constant(foo, fooType);
                var call = Expression.Call(instance, methodInfo);
                var lambda = Expression.Lambda(call);
                var compiledFunction = (Func<int>)lambda.Compile();
                return compiledFunction;
            }
        }
    }
