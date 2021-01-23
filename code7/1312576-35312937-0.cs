    private async void btnStart_Click(object sender, EventArgs e)
    {
      Msg.Clear();
      stopWatch.Reset();
      timer.Start();
      stopWatch.Start();
      lblTime.Text = stopWatch.Elapsed.TotalSeconds.ToString("#");
      progressBar.MarqueeAnimationSpeed = 30;
      try
      {
        await Task.Run(() => Reprocess());
      }
      catch (Exception ex)
      {
        Msg.Add(new clsMSG(ex.Message, "Error", DateTime.Now));
        timer.Stop();
        stopWatch.Stop();
        throw;
      }
    }
