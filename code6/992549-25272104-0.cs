    using Windows.Devices.Sensors;
    ...
    private void DisplayAccelReading(object sender, object args)
    {
        AccelerometerReading reading = _accelerometer.GetCurrentReading();
        if (reading == null)
            return;
        
        ScenarioOutput_X.Text = String.Format("{0,5:0.00}", reading.AccelerationX);
        ScenarioOutput_Y.Text = String.Format("{0,5:0.00}", reading.AccelerationY);
        ScenarioOutput_Z.Text = String.Format("{0,5:0.00}", reading.AccelerationZ);
    }
    ...
    private void DisplayGyroReading(object sender, object args)
    {
        GyrometerReading reading = _gyrometer.GetCurrentReading();
        if (reading == null)
            return;
        ScenarioOutput_AngVelX.Text = 
                      String.Format("{0,5:0.00}", reading.AngularVelocityX);
        ScenarioOutput_AngVelY.Text = 
                      String.Format("{0,5:0.00}", reading.AngularVelocityY);
        ScenarioOutput_AngVelZ.Text = 
                      String.Format("{0,5:0.00}", reading.AngularVelocityZ);
    }
