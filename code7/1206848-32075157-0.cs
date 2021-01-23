    Page_Loaded(object sender, EventArgs e)
    {
      if (CameraHandler != null)
      {
      	CameraHandler = new SDKHandler();
      	CameraHandler.LiveViewUpdated += new CameraHandler_LiveViewUpdated;
      	CameraHandler.ProgressChanged += CameraHandler_ProgressChanged;
      	CameraHandler.CameraHasShutdown += CameraHandler_CameraHasShutdown;
      	CameraHandler.ImageSaveDirectory = Settings.TempLocation;
      }
    }
