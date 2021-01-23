    var devices = await Windows.Devices.Enumeration.DeviceInformation.FindAllAsync(Windows.Devices.Enumeration.DeviceClass.VideoCapture);
     
    if (devices.Count < 1)
    {
        // There is no camera. Real code should do something smart here.
        return;
    }
    // Default to the first device we found
    // We could look at properties like EnclosureLocation or Name
    // if we wanted a specific camera
    string deviceID = devices[0].Id;
    // Go do something with that device, like start capturing!
 
