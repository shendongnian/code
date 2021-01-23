    public void SetConnected()
    {
        Dispatcher.BeginInvoke(new Action(() => {
          LabelColor = BgGrid.Resources["GreenBrush"] as Brush;
          LabelText = "Connected";
       });
    }
