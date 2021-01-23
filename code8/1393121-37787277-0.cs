    public void foo(Action del)
    {
        var local = del;
        if (local != null)
        {
            local();
        }
    }
    
    foo(() => 
    {
    var bar = 0;
    });
