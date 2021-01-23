    public interface IOperationContext<T>
    {
        IDictionary<string, T> Items { get; }
    }
    public class ThreadOperationContext<T> : IOperationContext<T>
    {
        [ThreadStatic]
        private static Dictionary<string, T> _items;
    
        public IDictionary<string, T> Items
        {
            get
            {
                if (_items == null)
                {
                    _items = new Dictionary<string, T>();
                }
                return _items;
            }
        } 
    }
    public class WcfOperationContext<T> : IExtension<OperationContext>
    {
        private readonly IDictionary<string, T> _items;
        private WcfOperationContext()
        {
            _items = new Dictionary<string, T>();
        }
        public IDictionary<string, T> Items
        {
            get { return _items; }
        }
        public static WcfOperationContext<T> Current
        {
            get
            {
                WcfOperationContext<T> context = OperationContext.Current.Extensions.Find<WcfOperationContext<T>>();
                if (context == null)
                {
                    context = new WcfOperationContext<T>();
                    OperationContext.Current.Extensions.Add(context);
                }
                return context;
            }
        }
        public void Attach(OperationContext owner) { }
        public void Detach(OperationContext owner) { }
    }
    /// <summary>
    /// Provides a collection that will be unique for every operation context.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class WcfOperationContextWrapper<T> : IOperationContext<T>
    {
        public IDictionary<string, T> Items
        {
            get { return WcfOperationContext<T>.Current.Items; }
        }
    }
