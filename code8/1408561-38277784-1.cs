    public class ActionEventArgs<T> : EventArgs
    {
      public Action<T> MyAction { get; set; } 
    }
    ...
    public event EventHandler<ActionEventArgs<string>> UploadProgress;
    ...
    if (UploadProgress != null)
    {
      var e = new ActionEventArgs<string>();
      e.MyAction = new Action<string>(myString =>
      {
        ...
        string.Format("sending file data {0:0.000}%", (bytesSoFar*100.0f)/totalToUpload);
      });
      UploadProgress.Invoke(this, e);
    }
    ...
    c.UploadProgress += C_UploadProgress;
    ...
    private void C_UploadProgress(object sender, ActionEventArgs<string> e)
    {
      Trace.Write(e.MyAction);
    }
