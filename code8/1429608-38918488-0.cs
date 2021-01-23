    private void LongRunningMethod(string path) {
      stopwatch.Start();
      TimeSpan ts = stopwatch.Elapsed;
      string name = string.Format("{0}:{1}", Math.Floor(ts.TotalMinutes), ts.ToString("ss\\.ff"));
      if (lblTimer.InvokeRequired) {
        lblTimer.BeginInvoke(new MethodInvoker(delegate {
          lblTimer.Text = name; 
        }));
      } else {
        lblTimer.Text = name; 
      }
      stopwatch.Stop();
    }
