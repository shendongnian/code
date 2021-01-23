    public abstract class BaseService
    {
        protected ILogger Logger { get; private set; }
        protected BaseService(Type type)
        {
            Logger = LogManager.GetLogger(type.FullName);
        }
    }
    public class ChildClass : BaseService
    {
        public ChildClass()
            : base(typeof(ChildClass)) //fast
        {
        }
        public void DoStuff()
        {
            Logger.Info("Some info");
        }
    }
