            private async void viewActivated(CoreApplicationView sender, IActivatedEventArgs args1)
        {
            FileOpenPickerContinuationEventArgs args = args1 as FileOpenPickerContinuationEventArgs;
            if (args != null)
            {
                if (args.Files.Count == 0) return;
                view.Activated -= viewActivated;
                foreach (var item in args.Files)
                {
                    // instead of item args.Files[0];
                    StorageFile storageFile = item;
                    var stream = await storageFile.OpenAsync(FileAccessMode.Read);
                    var bitmapImage = new BitmapImage();
                    await bitmapImage.SetSourceAsync(stream);
                    
                    var wbImage = new WriteableBitmap(bitmapImage.PixelWidth, bitmapImage.PixelHeight);
                    wbImage.SetSource(stream);
                    //var decoder = await Windows.Graphics.Imaging.BitmapDecoder.CreateAsync(stream);
                    //bitmapImage.UriSource = new Uri(item.Path, UriKind.Absolute);
                    if (myImageList.Count < 4)
                    {
                        myImageList.Add(bitmapImage);
                        alt_myImageList.Add(item);
                        ErrorMessage.Text = "";
                    }
                    else
                    {
                        ErrorMessage.Text = "Please pick not more than 4 pictures";
                    }
               }
           }
