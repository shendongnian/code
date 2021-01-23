    List<Task> tasks = new List<Task>();
    buttonUpdateImage.Enabled = false; // disable button
    foreach (OLVListItem item in cellsListView.CheckedItems)
    {
        Cell c = (Cell)(item.RowObject);
        var task = Task.Factory.StartNew(() =>
        {
            Process p = new Process();
            ...
            p.Start();
            p.WaitForExit();
        }).ContinueWith(t => c.Status = 0); // this modification is very important, Please note it, this will fix a problem
        tasks.Add(task);
    }
        
    // your code has been modified to just make the task object 
    // is the continued task instead of the task is the original task 
    // Task.WaitAll and add this instead of it.
    Task.Factory.ContinueWhenAll(tasks.ToArray(), ac => buttonUpdateImage.Enabled = true;);    
