    Task<List<Object>> myTask = Task<List<Object>>.Factory.StartNew(() =>
    {
        //business logic creating an Object to return 
        //return Object created
    })
    .ContinueWith((antecedant) =>
    {
        //business logic : needs to use antecedant
    }, TaskScheduler.FromCurrentSynchronizationContext());
