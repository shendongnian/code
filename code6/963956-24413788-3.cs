    using System;
    using System.Reflection;
    using PostSharp.Aspects;
    internal class Program
    {
        #region Methods
        private static void Main(string[] args)
        {
            Action action = () => { Console.WriteLine("Action called."); };
            Console.WriteLine(C.MyWrapper1(action));
        }
        #endregion
    }
    [Scaffolding(AttributeTargetMembers = "MyWrapper*")]
    internal static class C
    {
        #region Public Methods and Operators
        public static uint MyWrapper1(Action a)
        {
            DoSomething1();
            return Stub(a);
        }
        #endregion
        #region Methods
        private static void DoSomething1() { Console.WriteLine("DoSomething1"); }
        private static uint Stub(Action a) { return 0; }
        #endregion
    }
    internal static class ExternalStubClass
    {
        #region Public Methods and Operators
        public static uint Stub(Action a)
        {
            a.Invoke();
            return 5;
        }
        #endregion
    }
    [Serializable]
    public class ScaffoldingAttribute : OnMethodBoundaryAspect
    {
        #region Fields
        private MethodInfo doSomethingInfo;
        #endregion
        #region Public Methods and Operators
        public override void CompileTimeInitialize(MethodBase method, AspectInfo aspectInfo)
        {
            Type type = typeof(C);
            this.doSomethingInfo = type.GetMethod(method.Name.Replace("MyWrapper", "DoSomething"), BindingFlags.NonPublic | BindingFlags.Static);
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            this.doSomethingInfo.Invoke(null, null);
            args.ReturnValue = ExternalStubClass.Stub(args.Arguments[0] as Action);
            args.FlowBehavior = FlowBehavior.Return;
        }
        #endregion
    }
