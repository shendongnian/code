    using System;
    using System.Reflection;
    using PostSharp.Aspects;
    internal class Program
    {
        #region Methods
        private static void Main(string[] args)
        {
            Func<int> getMeNumber = () => { return 3; };
            Console.WriteLine(C.MyWrapper1(getMeNumber));
        }
        #endregion
    }
    [Scaffolding]
    internal static class C
    {
        #region Public Methods and Operators
        public static int MyWrapper1(Func<int> a)
        {
            //Do something
            return a.Invoke();
        }
        #endregion
    }
    internal static class D
    {
        #region Public Methods and Operators
        public static int MyWrapper1(Func<int> a) { return Convert.ToInt32(Math.Pow(a.Invoke(), 2)); }
        #endregion
    }
    [Serializable]
    public class ScaffoldingAttribute : OnMethodBoundaryAspect
    {
        #region Fields
        private MethodInfo methodInfo;
        #endregion
        #region Public Methods and Operators
        public override void CompileTimeInitialize(MethodBase method, AspectInfo aspectInfo)
        {
            Type type = typeof(D);
            this.methodInfo = type.GetMethod(method.Name);
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            args.ReturnValue = this.methodInfo.Invoke(null, args.Arguments.ToArray());
            args.FlowBehavior = FlowBehavior.Return;
        }
        #endregion
    }
