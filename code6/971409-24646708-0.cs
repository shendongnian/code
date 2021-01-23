    private void ProcessFrame(object sender, EventArgs arg) {
                this.Dispatcher.Invoke((Action)(() => {
                  try 
                  {
                    using(var frame = capture.RetrieveBgrFrame())
                    {
                              webCamDisplay.Source = BitmapSourceConvert.ToBitmapSource(frame);
                              webCamManager.Update(frame);
                    }
                    capture.Pause();
                  } 
                  catch (Exception ex) 
                  {
                          string msg = ex.Message;
                  }
                }));
    }
