        SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;
        public void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            if (e.Mode==PowerModes.StatusChange && SystemInformation.PowerStatus.BatteryChargeStatus==BatteryChargeStatus.Charging)
                //your action
        }
