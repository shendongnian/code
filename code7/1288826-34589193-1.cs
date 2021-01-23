    public async void ContinueFileOpenPicker(FileOpenPickerContinuationEventArgs args)
        {
            try
            {
                if (args.Files.Count > 0)
                {
                    StorageFile sf = args.Files[0];
                    await sf.CopyAsync(ApplicationData.Current.LocalFolder, args.Files[0].Name, NameCollisionOption.ReplaceExisting);
                    System.Diagnostics.Debug.WriteLine(sf.Name);
                    ApplicationData.Current.LocalSettings.Values["GImage"] = sf.Name;
                    var stream = await args.Files[0].OpenAsync(Windows.Storage.FileAccessMode.Read);
                    await bitmapImage.SetSourceAsync(stream);
                    userImage.Source = bitmapImage;      
                }
                else
                {
                }
            }
            catch { }
        }
