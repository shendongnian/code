    // untested 
    Task<List<Employee>> t1 = Task.Factory.StartNew(() => Method1());
    Task<List<Employee>> t2 = Task.Factory.StartNew(() => Method2());
    
    var result = t1.Result.Concat(t2.Result);
