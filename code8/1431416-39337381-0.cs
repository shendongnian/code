    private async void saveImage(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("********** Function STARTED: Save QR code as image to jpg **********");
            try
            {
                System.Diagnostics.Debug.WriteLine("Searching for assets folder.");
                var package = Windows.ApplicationModel.Package.Current.InstalledLocation;
                StorageFolder localFolder = await package.GetFolderAsync("Assets");
                StorageFile file = await localFolder.CreateFileAsync("savedimage.jpg", CreationCollisionOption.ReplaceExisting);
                var renderTargetBitmap = new RenderTargetBitmap();
                System.Diagnostics.Debug.WriteLine("Rendering an image.");
                await renderTargetBitmap.RenderAsync(QRimage);
                var pixels = await renderTargetBitmap.GetPixelsAsync();
                using (IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.ReadWrite))
                {
                    System.Diagnostics.Debug.WriteLine("Save QR code to jpg.");
                    var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, stream);
                    byte[] bytes = pixels.ToArray();
                    encoder.SetPixelData(
                        BitmapPixelFormat.Bgra8,
                        BitmapAlphaMode.Straight,
                        (uint)renderTargetBitmap.PixelWidth,
                        (uint)renderTargetBitmap.PixelHeight,
                        DisplayInformation.GetForCurrentView().LogicalDpi,
                        DisplayInformation.GetForCurrentView().LogicalDpi,
                        bytes);
                    await encoder.FlushAsync();
                }
                MessageDialog SuccessMsg = new MessageDialog("Code QR saved.");
                await SuccessMsg.ShowAsync();
            }
            catch (Exception ex)
            {
                //MessageDialog ErrMsg = new MessageDialog("Error Ocuured!");  
                System.Diagnostics.Debug.WriteLine("ERROR ZAPISU PLIKU: " + ex);
            }
            Debug.WriteLine("********** Function STOPPED: Save QR code as image to jpg **********");
        }
