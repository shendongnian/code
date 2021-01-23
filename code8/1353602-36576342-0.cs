    List<Tuple<Details, Context>> trace; 
    // add
    trace.Add(new Tuple(new Details(), new Context()));
    // iterate
    foreach(var item in trace)
        if(item.Item1?.date == ... && item.Item2?.context != null) { ... }
