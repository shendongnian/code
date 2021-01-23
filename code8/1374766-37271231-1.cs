    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        Uri uri = new Uri("xxxx(uri address)");
        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response != null && response.StatusCode == HttpStatusCode.Ok)
                {
                    string filename = "test.jpg";
                    var imageFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
                    using (IRandomAccessStream stream = await imageFile.OpenAsync(FileAccessMode.ReadWrite))
                    {
                        await response.Content.WriteToStreamAsync(stream);
                    }
                    StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync(filename);
                    //show original image in the Image control
                    IRandomAccessStream inputStream1 = await file.OpenReadAsync();
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.SetSource(inputStream1);
                    originalimg.Source = bitmap;
    
                    //use the blureffect
                    IRandomAccessStream inputStream = await file.OpenReadAsync();
                    BlurEffect blureffect = new BlurEffect();
                    inputStream.Seek(0);
                    blureffect.Source = new Lumia.Imaging.RandomAccessStreamImageSource(inputStream);
                    var render = new SwapChainPanelRenderer(blureffect, SwapChainPanelTarget);
                    await render.RenderAsync();
                }
            }
            catch
            {
            }
        }
    }
