        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            IsProcessing = true;
            await Dispatcher.Yield();
            // the UI is now showing that processing is going on
            Message = await DoProcessing();
            // update the other properties with the results
            IsProcessing = false;
            Thread.Sleep(5000);
        }
        private async Task<string> DoProcessing()
        {
           // Simulate heavy lifting here:
           await Task.Delay(TimeSpan.FromSeconds(5));
           return "Done processing";
        }
