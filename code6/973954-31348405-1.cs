    private async void viewActivated(CoreApplicationView sender, IActivatedEventArgs args1)
    {
      FileOpenPickerContinuationEventArgs args = args1 as FileOpenPickerContinuationEventArgs;
     
      if (args != null)
      {
          if (args.Files.Count == 0) return;
     
          view.Activated -= viewActivated;
          StorageFile storageFile = args.Files[0];
          var stream = await storageFile.OpenAsync(Windows.Storage.FileAccessMode.Read);
          var bitmapImage = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
          await bitmapImage.SetSourceAsync(stream);
     
          var decoder = await Windows.Graphics.Imaging.BitmapDecoder.CreateAsync(stream);
          img.Source=bitmapImage;
      }
    }
