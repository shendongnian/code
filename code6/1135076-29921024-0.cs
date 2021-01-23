            public async void Protect()
            {
                for (int i = 1; i < 24; i++)
                {
                    string imageFile = ImagePages[i];
                    var fileToEncrypt = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(imageFile);
                    var encryptedFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("encryptedPage" + i);
    
                    EncryptFile(fileToEncrypt, encryptedFile);
                    IBuffer buffer = await DecryptFile(encryptedFile);
                    //(2.) It goes here and throw the 'System.ArgumentException' having the encryptedFile's ContentType=""
    
                    var bmp = new BitmapImage();
                    await bmp.SetSourceAsync(buffer.AsStream().AsRandomAccessStream());
    
                    //Fill the List responsible for the Portrait View
                    MyPortrait mp = new MyPortrait();
                    mp.onlyImage = bmp;
                    PImageList.Add(mp);
                }
            }    
    
            public async void EncryptFile(IStorageFile fileToEncrypt, IStorageFile encryptedFile)
            {
                IBuffer buffer = await FileIO.ReadBufferAsync(fileToEncrypt);
                //I have no more exeptions here
                DataProtectionProvider dataProtectionProvider = new DataProtectionProvider("LOCAL=user");
    
                IBuffer encryptedBuffer = await dataProtectionProvider.ProtectAsync(buffer);
                //(1.) After arriving here when deploying it goes to (2.)
    
                await FileIO.WriteBufferAsync(encryptedFile, encryptedBuffer);
            }
    
            public async Task<IBuffer> DecryptFile(IStorageFile encryptedFile)
            {
                var protectedBuffer = await FileIO.ReadBufferAsync(encryptedFile);
    
                var dataProtectionProvider = new DataProtectionProvider();
    
                var buffer = await dataProtectionProvider.UnprotectAsync(protectedBuffer);
    
                return buffer;
            }
