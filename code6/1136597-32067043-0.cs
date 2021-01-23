    private void onFrameEvent(object sender, EventArgs e)
    {
          uEye.Camera Camera = sender as uEye.Camera;
    
          Int32 s32MemID;
          Camera.Memory.GetActive(out s32MemID);
          if (frameCamera != null)
                frameCamera.Dispose();
          frameCamera = null;
          Camera.Memory.ToBitmap(s32MemID, out frameCamera);
    
          Dispatcher.Invoke(new Action(() =>
          {
                pbMainImage.Source = loadBitmap(frameCamera);
          }));
    }
