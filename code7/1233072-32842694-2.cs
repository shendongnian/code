    // read
    DateTime lastCalibration = Settings.Default.LastCalibration;
    // save
    Settings.Default.LastCalibration = DateTime.Now;
    Settings.Default.Save();
