    [HttpPost]
    public void PushSensorData(SensorData data)
    {
        // data and its properties should be populated, ready for processing
        // its unnecessary to deserialize the string yourself.
        // assuming data isn't null, you can access the data by dereferencing properties:
        Debug.WriteLine(data.Type);
        Debug.WriteLine(data.Id);
    }
