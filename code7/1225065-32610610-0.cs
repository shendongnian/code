    public void SomeMethod()
    {
        var trace = new Trace();
        try
        {
            ... rest of method
        }
        finally
        {
            trace.EndTrace();
        }
    }
    public class TraceMethod : Attribute
    {
        public TraceMethod() => StartTrace();
        public void StartTrace() { ... }
        public void EndTrace() { ... }
    }
