    public void define(string symbol, Object definition)
    {
        object oldDefinition;
        if (table.TryGetValue(symbol, out oldDefinition) && oldDefinition != null) 
        {
            IDisposable disp = oldDefinition as IDisposable;
            if (disp != null)
            {
                disp.Dispose();
            }
        }
        table[symbol] = definition;
    }
