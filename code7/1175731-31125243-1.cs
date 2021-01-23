    private async void Button_Click(object sender, RoutedEventArgs e)
            {
                this.dialogPopUp.IsOpen = true;
                await Task.Run(() => DoWork());
                this.dialogPopUp.IsOpen = false;
    
            }
    
            private void DoWork()
            {
                Thread.Sleep(5000);
            }
