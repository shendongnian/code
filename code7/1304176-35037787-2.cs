    private void PingCompletedCallback(object sender, PingCompletedEventArgs e)
    {
      if(e.Cancelled)
      {
         txtResult.Text = "Cancelled";
         txtStatus.Text = "Cancel done";
      }
      else
      {
         txtResult.Text = e.Reply.Status.ToString();
         txtStatus.Text = "SendAsync done";
      }
    }
