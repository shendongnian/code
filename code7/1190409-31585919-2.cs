     private async void TakePhoto_Click(object sender, RoutedEventArgs e)
        {
            if (_mediaCapture != null)
            {
                try
                {
                    ImageEncodingProperties encodingProperties = ImageEncodingProperties.CreateJpeg();
                    WriteableBitmap bitmap = new WriteableBitmap((int)ImageElement.Width, (int)ImageElement.Height);
                    using (var imageStream = new InMemoryRandomAccessStream())
                    {
                        await this._mediaCapture.CapturePhotoToStreamAsync(encodingProperties, imageStream);
                        await imageStream.FlushAsync();
                        imageStream.Seek(0);
                        bitmap.SetSource(imageStream);
                        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
                                        () =>
                                        {
                                            ImageElement.Source = bitmap;
                                        });
                    }
                }
                catch (Exception ex)
                {
                    (new MessageDialog("Something went wrong !")).ShowAsync();
                }
            }
        }
 
