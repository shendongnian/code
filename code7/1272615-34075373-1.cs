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
                    handler(this, args);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error in the handler {0}: {1}", handler.Method.Name, e.Message);
                    exceptions.Add(e);
                }
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
