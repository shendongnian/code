    // Wrapper
    public class BandManager
    {
        // Callers will subscribe to this event
    	public event EventHandler<BandSensorReadingEventArgs<IBandAccelerometerReading>> ReadingChanged;
    	
    	public async Task ToggleAccelerometer()
    	{
    		if (!_sensorState[Sensor.Accelerometer])
    		{
    			_sensorState[Sensor.Accelerometer] = true;
    			_bandClient.SensorManager.Accelerometer.ReadingChanged += OnReadingChanged;
    			await _bandClient.SensorManager.Accelerometer.StartReadingsAsync();
    		}
    		else
    		{
    			_sensorState[Sensor.Accelerometer] = false;
    			await _bandClient.SensorManager.Accelerometer.StopReadingsAsync();
    		}
    	}
    	
    	private void OnReadingChanged(object sender, BandSensorReadingEventArgs<IBandAccelerometerReading> e)
    	{
    		var readingChangedHandler = ReadingChanged;
    		
    		if(readingChangedHandler != null)
    		{
    			ReadingChanged(this, e);
    		}
    	}
    }
    
    // Client
    public class MainClass
    {
    	public async void Test()
    	{
    		var bandManager = new BandManager();
    		bandManager.ReadingChanged += BandManager_ReadingChanged;
    		var whatever = await bandManager.ToggleAccelerometer();
    	}
    	
    	// This is event handler for your wrapper class
    	private void BandManager_ReadingChanged(object sender, BandSensorReadingEventArgs<IBandAccelerometerReading> e)
    	{
    		// use 'e' as you need
    	}
    }
