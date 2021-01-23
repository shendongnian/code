     private void BatteryStatus()
        {
            System.Management.ManagementClass wmi  = new System.Management.ManagementClass("Win32_Battery");
            var allBatteries = wmi.GetInstances();
            foreach (var battery in allBatteries)
            {
                int estimatedChargeRemaining = Convert.ToInt32(battery["EstimatedChargeRemaining"]);
                label13.Text = "Remaining" + "  " + estimatedChargeRemaining.ToString() + "  " + "%";
                if (estimatedChargeRemaining < 15 )
                {
                    label13.ForeColor = Color.Red;
                }
            }
        }
