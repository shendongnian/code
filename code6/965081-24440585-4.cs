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
    
        private object _obj;
    }
