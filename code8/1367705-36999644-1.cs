	public void TurnOn(float intensity)
	{
		var captureDevice = AVCaptureDevice.DefaultDeviceWithMediaType(AVMediaType.Video);
		if (captureDevice == null)
		{
		  Debug.WriteLine("No captureDevice - this won't work on the simulator, try a physical device");
		  return;
		}
		NSError error = null;
		captureDevice.LockForConfiguration(out error);
		if (error != null)
		{
		  Debug.WriteLine(error);
		  captureDevice.UnlockForConfiguration();
		  return;
		}
		else
		{
		  if (captureDevice.TorchMode != AVCaptureTorchMode.On)
		  {
			captureDevice.TorchMode = AVCaptureTorchMode.On;
            NSError err;
			captureDevice.SetTorchModeLevel(intensity, out err); // add this line
		  }
		  captureDevice.UnlockForConfiguration();
		}
	}
