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
        });
        task.ContinueWith(t => c.Status = 0);
        tasks.Add(task);
    }
        
    // your code is un-touched at all, just remove the 
    // Task.WaitAll and add this instead of it.
    Task.Factory.ContinueWhenAll(tasks.ToArray(), ac => buttonUpdateImage.Enabled = true;);    
