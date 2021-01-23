    async void SaveButtonClick(object sender, EventArgs e)
    {
      if (SaveFileDialog.ShowDialog() == DialogResult.OK)
      {
        var progress = new Progress<int>(ProgressWindow.SetPercentageDone);
        var task = Task.Run(() => Save(SaveFileDialog.FileName, progress));
        ProgressWindow = new ProgressForm();
        ProgressWindow.SetPercentageDone(0);
        ProgressWindow.ShowDialog(this);
        await task;
        ProgressWindow.Close();
      }
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
