    // Expose  just what is visible to your final Subclass on the interface
    public interface IExecutableJobPlugin
    {
        bool IsActive { get; set; }
        void CheckParameter();
        void Initialize(IDictionary parameters);
    }
    public class ExecutableJobPlugin : JobPlugin, IExecutableJobPlugin 
    {
        // Default implementation. NB, not abstract
        public void Initialize(IDictionary parameters) {}
        // This isn't visible on the interface
        protected override sealed void Invoke(IDictionary parameters)
        {
            //final realization of Invoke() method
        }
    }
    public class ConcreteExecutablePlugin : IExecutableJobPlugin
    {
        // Compose a decoupled IExecutableJobPlugin instead of direct inheritance
        private readonly IExecutableJobPlugin _wrappedJobPlugin;
        public ConcreteExecutablePlugin(IExecutableJobPlugin wrapped)
        {
            _wrappedJobPlugin = wrapped;
        }
        // Invoke() isn't on the interface so cannot be accessed here
        public void Initialize(IDictionary parameters)
        {
            // Call 'super' if needed.
            _wrappedJobPlugin.Initialize(parameters);
            //concrete plugin initialization code here ...
        }
        public bool IsActive
        {
            get { return _wrappedJobPlugin.IsActive; }
            set { _wrappedJobPlugin.IsActive = value; }
        }
        public void CheckParameter()
        {
            _wrappedJobPlugin.CheckParameter();
        }
    }
