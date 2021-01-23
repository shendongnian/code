    private async Task CaptureBackAndFront()
    {  
    //front Camera capture...
            DeviceInformationCollection webcamList;
            webcamList = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);
            DeviceInformation backWebcam;
            backWebcam = (from webcam in webcamList
                          where webcam.EnclosureLocation != null && webcam.EnclosureLocation.Panel == Windows.Devices.Enumeration.Panel.Back
                          select webcam).FirstOrDefault();
            
            MediaCapture newCapture = new MediaCapture();
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            try
            {
                await newCapture.InitializeAsync(new MediaCaptureInitializationSettings()
                {
                    VideoDeviceId = backWebcam.Id
                });
                cp.Source = newCapture;
                await newCapture.StartPreviewAsync();
                var picPath = "Image_Test_" + Convert.ToString(new Random());
                StorageFile captureFile = await folder.CreateFileAsync(picPath, CreationCollisionOption.GenerateUniqueName);
                ImageEncodingProperties imageProperties = ImageEncodingProperties.CreateJpeg();
                //Capture your picture into the given storage file
                await newCapture.CapturePhotoToStorageFileAsync(imageProperties, captureFile);
                BitmapImage bitmapToShow = new BitmapImage(new Uri(captureFile.Path));
                imagePreivew.Source = bitmapToShow;  // show image on screen inside Image 
                captureFile = null;
            }
            catch (Exception ex)
            {
                //handel error situation...
            }
            finally
            {
                await newCapture.StopPreviewAsync();
                newCapture.Dispose();
            }
            // Code to take front camera pic
            MediaCapture newFrontCapture = new MediaCapture();
            try
            {
                var frontWebCam = (from webcam in webcamList
                                   where webcam.EnclosureLocation != null
                                   && webcam.EnclosureLocation.Panel == Windows.Devices.Enumeration.Panel.Front
                                   select webcam).FirstOrDefault();
                await newFrontCapture.InitializeAsync(new MediaCaptureInitializationSettings()
                {
                    VideoDeviceId = frontWebCam.Id,
                });
                cp.Source = newFrontCapture;
                await newFrontCapture.StartPreviewAsync();
                var picFront = "Image_Test_Front" + Convert.ToString(new Random());               
                StorageFile captureFrontFile = await folder.CreateFileAsync(picFront, CreationCollisionOption.GenerateUniqueName);
                ImageEncodingProperties imageFrontProperties = ImageEncodingProperties.CreateJpeg();
                //Capture your picture into the given storage file
                await newFrontCapture.CapturePhotoToStorageFileAsync(imageFrontProperties, captureFrontFile);
                BitmapImage bitmapToShowFront = new BitmapImage(new Uri(captureFrontFile.Path));
                imagePreivew1.Source = bitmapToShowFront;
            }
            catch (Exception ex)
            {
                // Hanel error situation...
            }
            finally
            {
                await newFrontCapture.StopPreviewAsync();
                newFrontCapture.Dispose();
                newFrontCapture = null;
            }
        }
    }
