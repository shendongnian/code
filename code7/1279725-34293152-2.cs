    QueryResultRows<PO> pos = Db.SQL<PO>("SELECT po FROM PO po");
    List<Task>tasks = new List<Task>();
    foreach (var po in pos)
    {
        DbSession dbSession = new DbSession();
        var task = Task.Run(()=>
        dbSession.RunSync(() =>
        {
            // Do some stuff in the Starcounter database
        }));
        tasks.Add(Task);
    }
    Task.WaitAll(tasks.ToArray());
