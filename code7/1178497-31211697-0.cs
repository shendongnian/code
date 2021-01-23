    private async void HeartRate_ReadingChanged(object sender, Microsoft.Band.Sensors.BandSensorReadingEventArgs<Microsoft.Band.Sensors.IBandHeartRateReading> e)
    {
         await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, 
                   () => 
                   {
                       txtStatus.Text = string.Format("Current Heart Rate is: {0}", e.SensorReading.HeartRate.ToString())
                   }).AsTask();
    }
