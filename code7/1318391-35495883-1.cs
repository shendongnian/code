    private void ButtonClick(Object sender, EventArgs e)
    {
      var progress = new Progress<int>(valuePBar => { this.progressBar.Value = valuePBar; });
      MyMethod(progress);
    }
    MyMethod(IProgress<int> progress)
    {
      ...
      progress.Report(50);
      ...
    }
