    Thread.MemoryBarrier(); // read barrier
    var list = CommandList;
    
    if (list != null)
    {
        var next = list.Next;
        if (Interlocked.CompareExchange(ref CommandList, next, list) == list)
        {
           // execute code on 'list'.
        }
        else 
        {
           // something changed. Try again.
        }
    }
