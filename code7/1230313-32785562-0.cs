        <code>
        public MainViewModel()
        {
        //The firs time, launch to method for get the current status battery
                this.RequestAggregateBatteryReport();
        // This event is launch each time, when the status battery change
                Battery.AggregateBattery.ReportUpdated += AggregateBattery_ReportUpdated1;
    
            }
    
            private async void AggregateBattery_ReportUpdated1(Battery sender, object args)
                {
        //The Dispatcher is used when in other thread because is important use the other thread for avoid issue.
    Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                    () =>
                    {
                        RequestAggregateBatteryReport();
                    });
            }
    
       private void RequestAggregateBatteryReport()
            {
                // Create aggregate battery object
                var aggBattery = Battery.AggregateBattery;
    
                // Get report
                var report = aggBattery.GetReport();
    
                // Update UI
                AddReportUI(report, aggBattery.DeviceId);
            }
    
            private void AddReportUI(BatteryReport report, string DeviceID)
            {
                this.BatteryEnergy = new BatteryEnergy();
    
                // Disable progress bar if values are null
                if ((report.FullChargeCapacityInMilliwattHours == null) ||
                    (report.RemainingCapacityInMilliwattHours == null))
                {
                    
                    this.BatteryEnergy.ProgressBarMaxium = 0.0;
                    this.BatteryEnergy.ProgressBarValue = 0.0;
                    this.BatteryEnergy.ProgressBarPorcent = "N/A";
                }
                else
                {
                    
    
                    this.BatteryEnergy.ProgressBarMaxium = Convert.ToDouble(report.FullChargeCapacityInMilliwattHours);
                    this.BatteryEnergy.ProgressBarValue = Convert.ToDouble(report.RemainingCapacityInMilliwattHours);
                    this.BatteryEnergy.ProgressBarPorcent = ((Convert.ToDouble(report.RemainingCapacityInMilliwattHours) / Convert.ToDouble(report.FullChargeCapacityInMilliwattHours)) * 100).ToString("F2") + "%";
                }
            }
