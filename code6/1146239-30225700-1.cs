    partial class Form1 
    {
        private bool Disposed;
        ....
    }
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
                updateStuff.Dispose();
                Disposed = true;
        }
        base.Dispose(disposing);
    }
    private void updateStuff_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        if(!Disposed)
        {
              if (!channel.isOffline)
              {
                  object[] status = channel.GetACRCustom("P6144");
                  setText(System.Convert.ToString(status[0]));
              }
        }
    }
