    private async void OnGetImage(object sender, RoutedEventArgs e)
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(new Uri(txtUri.Text));
                BitmapImage bitmap = new BitmapImage();
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    {
                        using (var memStream = new MemoryStream())
                        {
                            await stream.CopyToAsync(memStream);
                            memStream.Position = 0;
                            bitmap.SetSource(memStream.AsRandomAccessStream());
                        }
                    }
                    this.img.Source = bitmap;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
