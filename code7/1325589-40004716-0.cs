    const int sizeMB = 500;
    using (MemoryFailPoint mem = new MemoryFailPoint(sizeMB))
    {
       // Allocate sizeMB - large object here. The allocation is *likely* going to succeed.
    }
    
