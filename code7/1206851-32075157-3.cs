    Page_Unloaded(object sender, EventArgs e)
    {
       if (!CameraHandler.IsFilming && CameraHandler.IsLiveViewOn)
       {
          CameraHandler.StopLiveView();
       }
       
       //maybe you were missing this
       if (CameraHandler.CameraSessionOpen) {
          CameraHandler.CloseSession();
       }
       CameraHandler.LiveViewUpdated -= CameraHandler_LiveViewUpdated;
       CameraHandler.ProgressChanged -= CameraHandler_ProgressChanged;
       CameraHandler.CameraHasShutdown -= CameraHandler_CameraHasShutdown;
       CameraHandler.Dispose();
       CameraHandler = null;
    }
