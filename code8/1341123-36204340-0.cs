    var link = txtSearchQuery.Text;
    for (var i = 1; i <= pageCount; i++)
    {
    
        tasks[i-1] = new Task(new Action(() => { Scrape(link, i); }));
        tasks[i-1].Start();
    }
    
    Task.Factory.ContinueWhenAll(tasks, completedTasks =>
    {
    // Do continuation work.
    });
