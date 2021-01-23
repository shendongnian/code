    using System;
    using System.Diagnostics;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Reflection.Emit;
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
                var compiledDirectCall = CompileBar(foo, asInterfaceCall: false);
                var compiledVirtualCall = CompileBar(foo, asInterfaceCall: true);
                var compiledArgDirectCall = CompileBar<FooImpl>();
                var compiledArgVirtualCall = CompileBar<IFoo>();
                var barMethodInfo = typeof(FooImpl).GetMethod(nameof(FooImpl.Bar));
                var iBarMethodInfo = typeof(IFoo).GetMethod(nameof(IFoo.Bar));
                var compiledToModuleDirect = CompileToModule<FooImpl>();
                var compiledToModuleVirtual = CompileToModule<IFoo>();
                var iterationCount = 200000000;
                var sw = Stopwatch.StartNew();
                for (int i = 0; i < iterationCount; i++)
                    compiledVirtualCall();
                var elapsedMs = sw.ElapsedMilliseconds;
                Console.WriteLine($"Compiled Virtual Call: {elapsedMs} ms");
                sw.Restart();
                for (int i = 0; i < iterationCount; i++)
                    compiledDirectCall();
                elapsedMs = sw.ElapsedMilliseconds;
                Console.WriteLine($"Compiled Direct Call: {elapsedMs} ms");
                sw.Restart();
                for (int i = 0; i < iterationCount; i++)
                    compiledArgVirtualCall(iFoo);
                elapsedMs = sw.ElapsedMilliseconds;
                Console.WriteLine($"Compiled w/ Arg Virtual Call: {elapsedMs} ms");
                sw.Restart();
                for (int i = 0; i < iterationCount; i++)
                    compiledArgDirectCall(foo);
                elapsedMs = sw.ElapsedMilliseconds;
                Console.WriteLine($"Compiled w/ Arg Direct Call: {elapsedMs} ms");
                sw.Restart();
                for (int i = 0; i < iterationCount; i++)
                    compiledToModuleVirtual(iFoo);
                elapsedMs = sw.ElapsedMilliseconds;
                Console.WriteLine($"Dynamic Module Virtual Call: {elapsedMs} ms");
                sw.Restart();
                for (int i = 0; i < iterationCount; i++)
                    compiledToModuleDirect(foo);
                elapsedMs = sw.ElapsedMilliseconds;
                Console.WriteLine($"Dynamic Module Direct Call: {elapsedMs} ms");
                sw.Restart();
                for (int i = 0; i < iterationCount; i++)
                    virtualLambda();
                elapsedMs = sw.ElapsedMilliseconds;
                Console.WriteLine($"Code Lambda Virtual Call: {elapsedMs} ms");
                sw.Restart();
                for (int i = 0; i < iterationCount; i++)
                    directLambda();
                elapsedMs = sw.ElapsedMilliseconds;
                Console.WriteLine($"Code Lambda Direct Call: {elapsedMs} ms");
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
                sw.Restart();
                for (int i = 0; i < iterationCount; i++) {
                    int result = (int)iBarMethodInfo.Invoke(iFoo, null);
                }
                elapsedMs = sw.ElapsedMilliseconds;
                Console.WriteLine($"Reflection Virtual Call: {elapsedMs} ms");
                sw.Restart();
                for (int i = 0; i < iterationCount; i++) {
                    int result = (int)barMethodInfo.Invoke(foo, null);
                }
                elapsedMs = sw.ElapsedMilliseconds;
                Console.WriteLine($"Reflection Direct Call: {elapsedMs} ms");
            }
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
            static Func<TInput, int> CompileBar<TInput>()
            {
                var fooType = typeof(TInput);
                var methodInfo = fooType.GetMethod(nameof(IFoo.Bar));
                var instance = Expression.Parameter(fooType, "foo");
                var call = Expression.Call(instance, methodInfo);
                var lambda = Expression.Lambda(call, instance);
                var compiledFunction = (Func<TInput, int>)lambda.Compile();
                return compiledFunction;
            }
            static Func<TInput, int> CompileToModule<TInput>()
            {
                var fooType = typeof(TInput);
                var methodInfo = fooType.GetMethod(nameof(IFoo.Bar));
                var instance = Expression.Parameter(fooType, "foo");
                var call = Expression.Call(instance, methodInfo);
                var lambda = Expression.Lambda(call, instance);
                var asmName = new AssemblyName(fooType.Name);
                var asmBuilder = AssemblyBuilder.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.Run);
                var moduleBuilder = asmBuilder.DefineDynamicModule(fooType.Name);
                var typeBuilder = moduleBuilder.DefineType(fooType.Name, TypeAttributes.Public);
                var methodBuilder = typeBuilder.DefineMethod(nameof(IFoo.Bar), MethodAttributes.Static, typeof(int), new[] { fooType });
                Expression.Lambda<Action>(lambda).CompileToMethod(methodBuilder);
                var createdType = typeBuilder.CreateType();
                var mi = createdType.GetMethods(BindingFlags.NonPublic | BindingFlags.Static)[1];
                var func = Delegate.CreateDelegate(typeof(Func<TInput, int>), mi);
                return (Func<TInput, int>)func;
            }
        }
    }
