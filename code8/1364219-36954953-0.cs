    public interface IInterpreter { }
    public interface IReceiver
    {
        bool Enabled { get; set; }
    }
    public class OwnInterpreter : IInterpreter
    {
        public void DoSomething() { }
    }
    public abstract class ReceiverBase<T> : IReceiver
        where T : IInterpreter, new()
    {
        public T MyReceiver { get; set; }
        internal abstract void Start();
        private bool _isEnabled;
        public bool Enabled { get { return _isEnabled; } set { _isEnabled = value; OnEnable(value); } }
        internal abstract void OnEnable(bool isEnabled);
        protected ReceiverBase()
        {
            MyReceiver = new T();
        }
    }
    public class SpecialReceiver : ReceiverBase<OwnInterpreter>
    {
        public void CheckSomething()
        {
            MyReceiver.DoSomething();
        }
        internal override void Start()
        {
            // just for testing puropses
            MyReceiver = new OwnInterpreter();
        }
        internal override void OnEnable(bool isEnabled)
        {
            MyReceiver = isEnabled ? new OwnInterpreter() : null;
        }
    }
    public class ReceiverFactory
    {
        public static IReceiver Create(string type)
        {
            switch (type)
            {
                default:
                    return new SpecialReceiver();
            }
        }
    }
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            ReceiverFactory.Create("");
        }
    }
