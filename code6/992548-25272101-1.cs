    using Windows.Devices.Sensors;
    
    private Accelerometer _accelerometer;
    
    private void DoStuffWithAccel()
    {
       _accelerometer = Accelerometer.GetDefault();
       if (_accelerometer != null)
       {
          AccelerometerReading reading = _accelerometer.GetCurrentReading();
          if (reading != null)
          double xreading = reading.AccelerationX;
          ... etc.
       }
    }
