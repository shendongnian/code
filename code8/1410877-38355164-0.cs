    using System;
    using System.Reflection;
    using PostSharp.Aspects;
    using PostSharp.Extensibility;
    
    namespace SandboxConsole
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                Console.WriteLine(GetText("Test"));
                Console.ReadLine();
            }
    
            [Decorate]
            public static string GetText(string name)
            {
                return String.Format("lorem ipsum, {0} dolor sit amet", name);
            }
        }
    
        [Serializable]
        [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
        public class DecorateAttribute : MethodInterceptionAspect
        {
            public override bool CompileTimeValidate(MethodBase method)
            {
                if (((MethodInfo)method).ReturnType != typeof(string))
                {
                    Message.Write(SeverityType.Error, "CUSTOM01", "Can not apply [Decorate] to method {0} because it does not retun string", method);
                    return false;
                }
                return true;
            }
    
            public override void OnInvoke(MethodInterceptionArgs args)
            {
                args.Proceed();
                args.ReturnValue = String.Format("<p>{0}</p>", args.ReturnValue);
            }
        }
    }
