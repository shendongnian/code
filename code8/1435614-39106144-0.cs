    public static class Contexts
    {
        [ThreadStatic]
        public Stack<Context> contexts;
        public Context CurrentContext
        {
            get
            {
                if (contexts == null || contexts.Count == 0) { return null; }
                return contexts.Peek();
            }
        }
        public void ContextCreated(Context obj)
        {
            if (contexts == null) { contexts = new Stack<Context>(); }
            contexts.Push(obj);
        }
        public void ContextDisposed()
        {
            if (contexts == null) { contexts = new Stack<Context>(); }
            contexts.Pop();
        }
    }
