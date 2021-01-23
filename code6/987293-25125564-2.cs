    public Task<List<MyDataObject>> Foo()
    {
        IEnumerable<string> names = GetList();
        var tasks = new List<Task<MyDataObject>>();
        foreach (var name in names)
        {
            tasks.Add(Task<MyDataObject>.Factory.StartNew(
                () =>
                {
                    var reply = new MyDataObject();
                    var workerObject = new WorkerObject();
                    workerObject.Foo2();
                    reply.Success = true;
                    return reply;
                }));
        }
        return WhenAll(tasks);
    }
