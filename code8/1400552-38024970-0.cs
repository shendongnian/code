    public void Work(IList<MyModel> data)
    {
       Parallel.ForEach(data, item=>{
           DoSomeTask(item);
       });
    }
