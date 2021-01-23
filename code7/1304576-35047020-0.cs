    public void OnPictureTaken(byte[] data, Android.Hardware.Camera camera)
    {
        camera.StopPreview();
        Toast.MakeText(this, "Cheese", ToastLength.Short).Show();
        camera.StartPreview();
    }
