    private async void buttonStart_Click(object sender, EventArgs e)
    {
      var cells = objectListView.CheckedObjects;
      if (cells == null)
        return;
      var workItems = cells.Select(c => new
      {
        Cell = c,
        Progress = new Progress<string>(value => { c.Status = value; }),
      }).ToList();
      await Task.Run(() => Parallel.ForEach(workItems, item =>
      {
        var progress = item.Progress as IProgress<string>();
        progress.Report("Starting...");
        int a = 123;
        for (int i = 0; i < 200000; i++)
        {
          a = a + i;
          Thread.Sleep(500);
        }
        progress.Report("Done");
      }));
      Console.WriteLine("Done, enabld UI controls");
    }
