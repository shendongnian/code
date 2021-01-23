    blink = !blink;
    while(blink)
        {
        PhotoCamera cam = new Microsoft.Devices.PhotoCamera(CameraType.Primary);
        cam.FlashMode = FlashMode.On;
        await Task.Wait(TimeSpan.FromSeconds(1));
        cam.FlashMode = FlashMode.Off;
        }
