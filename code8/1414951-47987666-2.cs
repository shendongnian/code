    [AttributeUsage(AttributeTargets.Method)]
    public class TestMethodAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new TestMethodHandler();
        }
    }
