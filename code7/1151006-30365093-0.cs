    Debug.WriteLine("InitializeCameraAsync");
    
                if (_mediaCapture == null)
                {
                    // Attempt to get the front camera if one is available, but use any camera device if not
                    var cameraDevice = await FindCameraDeviceByPanelAsync(Windows.Devices.Enumeration.Panel.Front);
    
                    if (cameraDevice == null)
                    {
                        Debug.WriteLine("No camera device found!");
                        return;
                    }
    
                    // Create MediaCapture and its settings
                    _mediaCapture = new MediaCapture();
    
                    // Register for a notification when video recording has reached the maximum time and when something goes wrong
                    _mediaCapture.RecordLimitationExceeded += MediaCapture_RecordLimitationExceeded;
                    _mediaCapture.Failed += MediaCapture_Failed;
    
                    var settings = new MediaCaptureInitializationSettings { VideoDeviceId = cameraDevice.Id };
    
                    // Initialize MediaCapture
                    try
                    {
                        await _mediaCapture.InitializeAsync(settings);
                        _isInitialized = true;
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Debug.WriteLine("The app was denied access to the camera");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Exception when initializing MediaCapture with {0}: {1}", cameraDevice.Id, ex.ToString());
                    }
    
                    // If initialization succeeded, start the preview
                    if (_isInitialized)
                    {
                        // Figure out where the camera is located
                        if (cameraDevice.EnclosureLocation == null || cameraDevice.EnclosureLocation.Panel == Windows.Devices.Enumeration.Panel.Unknown)
                        {
                            // No information on the location of the camera, assume it's an external camera, not integrated on the device
                            _externalCamera = true;
                        }
                        else
                        {
                            // Camera is fixed on the device
                            _externalCamera = false;
    
                            // Only mirror the preview if the camera is on the front panel
                            _mirroringPreview = (cameraDevice.EnclosureLocation.Panel == Windows.Devices.Enumeration.Panel.Front);
                        }
