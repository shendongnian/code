    public async Task<string> DownloadAndExtractFile(string source, string destination, string ItemDownload)
    {
      string zPath = @"C:\Program Files\7-Zip\7zG.exe";
      ProcessStartInfo pro = new ProcessStartInfo();
      pro.WindowStyle = ProcessWindowStyle.Hidden;
      pro.FileName = zPath;
      pro.Arguments = "x \"" + source + "\" -o" + destination;
      IProgress<int> progress = new Progress<int>(
          value => { Restore.frmRestore.progressBar1.Value = value; });
      await Task.Run(() =>
      {
        progress.Report(50);
        try
        {
          Process x = Process.Start(pro);
          Task.WaitAll();
          progress.Report(100);
          x.Close();
          Console.WriteLine("Extract Successful.");
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.ToString());
        }
      });
      return "Success";
    }
