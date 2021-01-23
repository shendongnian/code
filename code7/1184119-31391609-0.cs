    void timeElapsed(object sender, EventArgs e)
    {
        progressBar1.Value = (int)(power.BatteryLifePercent * 100);
        label1.Text = string.Format("{0}%", (power.BatteryLifePercent * 100));
        cpuCounter.CategoryName = "Processor";
        cpuCounter.CounterName = "% Processor Time";
        cpuCounter.InstanceName = "_Total";
        //var unused = cpuCounter.NextValue();
        progressBar2.Value = (int)(cpuCounter.NextValue());
        label2.Text = "CPU  " + progressBar2.Value.ToString() + "%";
    }
