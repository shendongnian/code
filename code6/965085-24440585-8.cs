    [DebuggerTypeProxy(CustomDebugView)]
    class Dimension
    {
    }
    
    // Debugger will show this object (calling its ToString() method
    // as required and showing its properties and fields)
    public class CustomDebugView
    {
        public CustomDebugView(object obj)
        {
            _obj = obj;
        }
        public override string ToString()
        {
            // Proxy is much more powerful than this because it
            // can expose a completely different view of your object but
            // you can even simply use it to invoke TypeConverter conversions.
            return _obj.ToString(); // Replace with true code
        }
    
        private object _obj;
    }
