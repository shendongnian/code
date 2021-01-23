    private async void startButton_Click(object sender, EventArgs e)
    {
          var progress = new Progress<int>(percent =>
          {
             fileProgressBar.Value = percent;
          });
          await Copy(progress);
          
          MessageBox.Show("Done");
    }
    void Copy(IProgress<int> progress)
    {
          Task.Run(() =>
          {
               CopyFileEx.FileRoutines.CopyFile(new FileInfo(@"C:\_USB\Fear.rar"), new FileInfo(@"H:\Fear.rar"), CopyFileEx.CopyFileOptions.All, callback, null,progress);
               complete = true;
          });
    }
