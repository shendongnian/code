    private async Task GetImages()
        {            
            foreach (var item in Itmes)           
            {
                var httpClient = new HttpClient();
                Stream st = await httpClient.GetStreamAsync(item.ImgLink);
                var memoryStream = new MemoryStream();
                await st.CopyToAsync(memoryStream);
                memoryStream.Position = 0;
                BitmapImage bitmap = new BitmapImage();
                bitmap.SetSource(memoryStream.AsRandomAccessStream());
                item.Img = bitmap;                
            }
        }
