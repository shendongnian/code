    var devices = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);
    if (devices.Count > 0)
                {
                    if (devices.Count >= 2)
                    {
                        var device = devices.Where(d => d.EnclosureLocation.Panel == Windows.Devices.Enumeration.Panel.Front).First();
                    }
                }
    //You need to implement GetFrontCameraVideoID,
    var frontVideoId = device.Id;
    await mc.InitializeAsync(new MediaCaptureInitializationSettings
                {
                MediaCategory = MediaCategory.Communications,
                StreamingCaptureMode = StreamingCaptureMode.AudioAndVideo,
                VideoDeviceId = frontVideoId
                });
    CaptureElement.Source = mc;
    await mc.StartPreviewAsync();
