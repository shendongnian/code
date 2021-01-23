        for(int i=0; i<1000 && !token.IsCancellationRequested; ++i)
        {
            ...
        }
        // output log if cancelled
        if (token.IsCancellationRequested) Console.WriteLine(...);
