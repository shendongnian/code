      private void BatteryStatus()
     {
        System.Management.ManagementClass wmi  = new System.Management.ManagementClass("Win32_Battery");
        var allBatteries = wmi.GetInstances();
        foreach (var battery in allBatteries)
        {
            int estimatedChargeRemaining = Convert.ToInt32(battery["EstimatedChargeRemaining"]); 
            string Status = "";    
            if(estimatedChargeRemaining < 15) Status = "Critical";
            else  if(estimatedChargeRemaining < 35) Status = "Low";
            else  if(estimatedChargeRemaining < 60) Status = "Regular";
            else  if(estimatedChargeRemaining < 90) Status = "High";
            else Status = "Complete";
            label13.Text = "Remaining:" + "  " + estimatedChargeRemaining + "  " + "% | Status: " + Status;
        }
    }
