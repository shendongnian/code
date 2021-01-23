    var options=new ExecutionDataflowBlockOptions
    {
        MaxDegreeOfParallelism = 10
    }
    var block=new ActionBlock<string>(url=>
    {
        using(var req = WebRequest.Create(url))
        using(var res = req.GetResponse())
        {
           //Process the response here   
        }
    });
    string[] lines = File.ReadAllLines(@"c:\data\temp.txt");
    foreach(var line in lines)
    {
        block.Post(line);
    }
    block.Complete();
    
    await block.Completion;
