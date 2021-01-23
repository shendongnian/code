    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Field)]
    public class LogAttribute : Attribute, IMethodDecorator
    {
        ILogger log = Logger.Factory.GetLogger<Logger>();
        String methodName;
        public String logMessage { get; set; }
        private Lazy<IEnumerable<PropertyInfo>> _properties;
        public MethodBase DecoratedMethod { get; private set; }
        public LogAttribute() {
            this._properties = new Lazy<IEnumerable<PropertyInfo>>(() =>
             this.GetType()
                 .GetRuntimeProperties()
                 .Where(p => p.CanRead && p.CanWrite));
        }
        public void Init(object instance, MethodBase method, object[] args)
        {
            this.UpdateFromInstance(method);
            methodName = method.Name;
        }
        public void OnEntry()
        {
            log.Debug("Inside" + methodName);
            log.Debug(logMessage);
        }
        public void OnExit()
        {
            Console.WriteLine("Exiting Method");
        }
        public void OnException(Exception exception)
        {
            Console.WriteLine("Exception was thrown");
        }
        private void UpdateFromInstance(MethodBase method)
        {
            this.DecoratedMethod = method;
            var declaredAttribute = method.GetCustomAttribute(this.GetType());
            foreach (var property in this._properties.Value)
                property.SetValue(this, property.GetValue(declaredAttribute));
        }
    }
