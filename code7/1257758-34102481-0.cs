    // Attempt to get the back camera if one is available,
    // but use any camera device if not.
    var cameraDevice = await FindCameraDeviceByPanelAsync(
                                 Windows.Devices.Enumeration.Panel.Back); 
    if (cameraDevice == null)
    {
        // This device has no camera.
    }
    else if (cameraDevice.EnclosureLocation == null ||
             cameraDevice.EnclosureLocation.Panel ==
                                 Windows.Devices.Enumeration.Panel.Unknown) 
    { 
         // We have an external camera.
    }
    else
    {
         // We have a built-in camera. The location is reported in
         // cameraDevice.EnclosureLocation.Panel.
    }
 
