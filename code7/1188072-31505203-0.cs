        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await Dispatcher.InvokeAsync(() => 
            {
                Debug.WriteLine("Visibility");
                lbl.Visibility = Visibility.Visible;                
            });
            await Task.Run(() =>
            {
                return Dispatcher.InvokeAsync(() => Thread.Sleep(3000));
            });            
        }
