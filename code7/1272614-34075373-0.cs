    protected virtual void OnArriveHome(BreadWinnerEventArgs args)
    {
        var t = ArrivedHome; // publisher uses sames signature as the delegate
        if (t != null)
        {
            foreach (EventHandler<BreadWinnerEventArgs> handler in t.GetInvocationList())
            {
                try
                {
                    handler(this, args);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error in the handler {0}: {1}", handler.Method.Name, e.Message);
                }
            }
        }
    }
