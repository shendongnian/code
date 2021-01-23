    public class Abc : MarshalByRefObject
    {
        public string City { get; set; }
        public string State { get; set; }
        private Abc()
        {
        }
        public static Abc NewInstance()
        {
            var proxy = new AbcProxy(new Abc());
            return (Abc)proxy.GetTransparentProxy();
        }
    }
    public class AbcProxy : RealProxy
    {
        private readonly Abc _realInstace;
        public AbcProxy(Abc instance) : base(typeof (Abc))
        {
            _realInstace = instance;
        }
        public override System.Runtime.Remoting.Messaging.IMessage Invoke(System.Runtime.Remoting.Messaging.IMessage msg)
        {
            var methodCall = msg as IMethodCallMessage;
            var methodInfo = methodCall.MethodBase as MethodInfo;
            Console.WriteLine("Before " + methodInfo.Name);
            try
            {
                var result = methodInfo.Invoke(_realInstace, methodCall.InArgs);
                Console.WriteLine("After " + methodInfo.Name);
                return new ReturnMessage(result, null, 0,
                 methodCall.LogicalCallContext, methodCall);
            }
            catch (Exception e)
            {
                return new ReturnMessage(e, methodCall);
            }
        }
    }
