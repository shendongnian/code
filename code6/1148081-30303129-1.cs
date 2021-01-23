    private void button1_Click(object sender, EventArgs e)
    {
      label1.Text = "Test";
      var progress = new Progress<string>(update => { label1.Text = update; });
      await Task.Run(() => MyMethod(progress));
    }
    public void MyMethod(IProgress<string> progress)
    {
      if (progress != null)
        progress.Report("");
      ...; // "lot of IO and stuff"
      if (progress != null)
        progress.Report("Done");
    }
