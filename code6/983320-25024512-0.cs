    private void cameraCapture_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult != TaskResult.OK) return;
            var capturedPhoto = new BitmapImage();
            capturedPhoto.SetSource(e.ChosenPhoto);
            ImgView.Source = capturedPhoto;
            FileName = today.ToString();
            
            {
                using (var memoryStream = new MemoryStream())
                {
                    // Get a stream of the captured photo
                    var writableBitmap = new WriteableBitmap(capturedPhoto);
                    writableBitmap.SaveJpeg(memoryStream, capturedPhoto.PixelWidth, capturedPhoto.PixelHeight, 0, 50);
                    PhotoResult photoResult = e as PhotoResult;
                    photoResult.ChosenPhoto.CopyTo(memoryStream);
                    memoryStream.Position = 0; // Rewind the stream
                    myPic = memoryStream.ToArray(); //  byte[] myPic; has been decleared in inital
                }
            }
        }
