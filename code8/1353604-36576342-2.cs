    List<ContextDetails> trace; 
    // add
    trace.Add(new ContextDetails()
    {
        Details = new Details(),
        Context = new Context(),
    });
    // iterate
    foreach(var item in trace)
        if(item.Details?.date == ... && item.Context?.context != null) { ... }
