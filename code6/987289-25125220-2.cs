    Task.WaitAll(tasks.ToArray());
    var replyList = new List<MyDataObject>();
    for (int i = 0; i < tasks.Count(); i++)
    {                replyList.Add(((Task<MyDataObject>)tasks[i]).Result);
    }
    var tcs = new TaskCompletionSource<List<MyDataObject>>();
    tcs.SetResult(replyList);
    return tcs.Task;
