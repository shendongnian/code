    private async void MyButton_Click(object sender, EventArgs e)
    {
        var tasks = items.Select(item => Task.Run(() => doWork(item))).ToList();
        while (tasks.Any())
        {
            var task = await Task.WhenAny(tasks);
            tasks.Remove(task);
            var result = await task;
            // update the UI using the result
        }
    }
