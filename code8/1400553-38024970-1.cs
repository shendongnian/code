    public void Work(IList<MyModel> data)
    {
       Task.WaitAll(data.Select(item=>{
           DoSomeTask(item);
       }));
    }
