    protected virtual void OnArriveHome(BreadWinnerEventArgs args)
    {  
        var t = ArrivedHome; // publisher uses sames signature as the delegate
        if (t != null)
        {
            var exceptions = new List<Exception>();
            foreach (EventHandler<BreadWinnerEventArgs> handler in t.GetInvocationList())
            {
                try
                {
                    try
                    {
                        handler(this, args);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error in the handler {0}: {1}", handler.Method.Name, e.Message);
                        throw new DelegateException(handler, e, this, args); //Throw the exception to capture the stack trace.
                    }
                }
                catch (DelegateException e)
                {
                    exceptions.Add(e);
                }
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
    ///Elsewhere
    sealed class DelegateException : Exception
    {
        public Delegate Handler { get; }
        public object[] Args { get; }
        public DelegateException(Delegate handler, Exception innerException, params object[] args) : base("A delegate raised an error when called.", innerException)
        {
            Handler = handler;
            Args = args;
        }
    }
