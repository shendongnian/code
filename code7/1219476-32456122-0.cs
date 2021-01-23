      void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                bitmap = (Bitmap)eventArgs.Frame.Clone();
                
                ///add these two lines to mirror the image
                var filter = new Mirror(false, true);
                filter.ApplyInPlace(bitmap);
                ///
                picFrame.Image = bitmap;
            }
            catch
            {
                
           
            }
          
        }
