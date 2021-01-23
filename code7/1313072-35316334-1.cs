    async void SaveButtonClick(object sender, EventArgs e)
    {
      if (SaveFileDialog.ShowDialog() == DialogResult.OK)
      {
        ProgressWindow = new ProgressForm();
        ProgressWindow.SetPercentageDone(0);
        var progress = new Progress<int>(ProgressWindow.SetPercentageDone);
        var task = SaveAndClose(SaveFileDialog.FileName, progress));
        ProgressWindow.ShowDialog(this);
        await task;
      }
    }
    async Task SaveAndClose(string path, IProgress<int> progress)
    {
      await Task.Run(() => Save(path, progress));
      ProgressWindow.Close();
    }
    void Save(string path, IProgress<int> progress)
    {
      // open file
      for (int i=0; i < 100; i++)
      {
        // get some stuff from UI
        // save stuff to file
        if (progress != null)
          progress.Report(i);
      }
      // close file
    }
