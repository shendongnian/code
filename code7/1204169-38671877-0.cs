    using System;
    using System.Reflection;
    using System.Reflection.Emit;
    #if true
    using MyType = Microsoft.FSharp.Core.FSharpOption<string>;
    #else
    using MyType = System.Tuple<ConsoleApplication27.Poco>;
    #endif
    namespace ConsoleApplication27
    {
        public class Poco
        {
        
        }
        class Program
        {
            static void Main(string[] args)
            {
                var something = new MyType(null);
                var dynMethod = new DynamicMethod("ChangeField", MethodAttributes.Public | MethodAttributes.Static,
                    CallingConventions.Standard, typeof(void), new[] {typeof(MyType)}, typeof(string).Module, true);
                var generator = dynMethod.GetILGenerator();
                generator.Emit(OpCodes.Ldarg_0);
                generator.Emit(OpCodes.Ldnull);
                generator.Emit(OpCodes.Stfld,
                    typeof(MyType).GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)[0]);
                generator.Emit(OpCodes.Ret);
                var method = (Action<MyType>) dynMethod.CreateDelegate(typeof(Action<MyType>));
                method(something);
                Console.WriteLine(typeof(MyType).GetProperties()[0].GetGetMethod().Invoke(something, new object[0]));
            }
        }
    }
