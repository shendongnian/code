    public event EventHandler<Action<string>> UploadProgress;
    ...
    if (UploadProgress != null)
    {
      var action = new Action<string>(myString =>
      {
        ...
        string.Format("sending file data {0:0.000}%", (bytesSoFar * 100.0f) / totalToUpload);
      });
      UploadProgress.Invoke(this, action);
    }
    ...
    c.UploadProgress += C_UploadProgress;
    ...
    private void C_UploadProgress(object sender, Action<string> e)
    {
      Trace.Write(e);
    }
