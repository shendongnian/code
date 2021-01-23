    List<Task> taskList = new List<Task>();
    ConcurrentBag<object> allObjectAttributes = new ConcurrentBag<object>();
    taskList.Add(Task.Factory.StartNew(() => allObjectAttributes.Add(GetObjectAttributes(TreeViewAttrs.Folder))));
    taskList.Add(Task.Factory.StartNew(() => allObjectAttributes.Add(GetObjectAttributes(TreeViewAttrs.XMLFile))));
    taskList.Add(Task.Factory.StartNew(() => allObjectAttributes.Add(GetObjectAttributes(TreeViewAttrs.TextFile))));
    taskList.Add(Task.Factory.StartNew(() => allObjectAttributes.Add(GetObjectAttributes(TreeViewAttrs.Parent))));
    Task.WaitAll(taskList.ToArray());
    return allObjectAttributes;
