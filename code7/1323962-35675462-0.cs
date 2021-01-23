    private async void button_Click(object sender, RoutedEventArgs e)
    {
      var progress = new Progress<int>(value => { this.progress.Value = value; });
      await Task.Run(() => aNewMethod(progress));
    }
    private void aNewMethod(IProgress<int> progress)
    {
      //Heavy work
      for (int i = 1; i < 1000000000; i++) { }
      progress.Report(100);
    }
