    void Main()
    {
        var cts = new CancellationTokenSource();
        cts.CancelAfter(TimeSpan.FromSeconds(2));
    
        var task = Task.Run(() => ReadLineFromConsole(cts.Token));
        task.Wait(cts.Token);
        
        if (task.IsCanceled)
        {
            Console.WriteLine("Too slow!");
            return;
        }
        
        var result = task.Result;
        
        if (result != "144")
        {
            Console.WriteLine("Wrong!");
            return;
        }
        
        // Continue
    }
    
    public string ReadLineFromConsole(CancellationToken token)
    {  
        var buffer = new StringBuilder();
        int ch;
        
        while (!token.IsCancellationRequested)
        {
            Console.In.Peek();
            
            token.ThrowIfCancellationRequested();
            
            ch = Console.In.Read();
            if (ch == -1) return buffer.Length > 0 ? buffer.ToString() : null;
    
            if (ch == '\r' || ch == '\n') 
            {
                if (ch == '\r' && Console.In.Peek() == '\n') Console.In.Read();
                return buffer.ToString();
            }
            
            buffer.Append((char)ch);
        }
        
        token.ThrowIfCancellationRequested();
        
        // Shouldn't be reached, but the compiler doesn't know that.
        return null;
    }
