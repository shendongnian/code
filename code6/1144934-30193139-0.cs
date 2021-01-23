        DateTime start;
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.viewModel.StatusMessage = "Connecting to Band";
                // Get the list of Microsoft Bands paired to the phone.
                IBandInfo[] pairedBands = await BandClientManager.Instance.GetBandsAsync();
                if (pairedBands.Length < 1)
                {
                    this.viewModel.StatusMessage = "This sample app requires a Microsoft Band paired to your phone. Also make sure that you have the latest firmware installed on your Band, as provided by the latest Microsoft Health app.";
                    return;
                }
                // Connect to Microsoft Band.
                using (IBandClient bandClient = await BandClientManager.Instance.ConnectAsync(pairedBands[0]))
                {
                    start = DateTime.Now;
                    this.viewModel.StatusMessage = "Reading ultraviolet sensor";
                    // Subscribe to Ultraviolet data.
                    bandClient.SensorManager.UV.ReadingChanged += UV_ReadingChanged;
                    await bandClient.SensorManager.UV.StartReadingsAsync();
                    // Receive Accelerometer data for a while.
                    await Task.Delay(TimeSpan.FromMinutes(5));
                    await bandClient.SensorManager.UV.StopReadingsAsync();
                    bandClient.SensorManager.UV.ReadingChanged -= UV_ReadingChanged;
                }
                this.viewModel.StatusMessage = "Done";
            }
            catch (Exception ex)
            {
                this.viewModel.StatusMessage = ex.ToString();
            }
        }
        void UV_ReadingChanged(object sender, Microsoft.Band.Sensors.BandSensorReadingEventArgs<Microsoft.Band.Sensors.IBandUVReading> e)
        {
            var span = (DateTime.Now - start).TotalSeconds;
            IBandUVReading ultra = e.SensorReading;
            string text = string.Format("Ultraviolet = {0}\nTime Stamp = {1}\nTime Span = {2}\n", ultra.IndexLevel, ultra.Timestamp, span);
            Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => { this.viewModel.StatusMessage = text; }).AsTask();
            start = DateTime.Now;
        }
