    private async void toDropBoxBtn_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      System.Threading.Thread thread = new System.Threading.Thread(getMyToken);
      thread.Start();
    }
