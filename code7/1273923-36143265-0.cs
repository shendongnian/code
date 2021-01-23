    public static class BandIconUtil
    {
        public static async Task<BandIcon> FromAssetAsync(string iconFileName, int size = 24)
        {
            string uri = "ms-appx:///" + iconFileName;
            StorageFile imageFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri(uri, UriKind.RelativeOrAbsolute));
            using (IRandomAccessStream fileStream = await imageFile.OpenAsync(FileAccessMode.Read))
            {
                WriteableBitmap bitmap = new WriteableBitmap(size, size);
                await bitmap.SetSourceAsync(fileStream);
                return bitmap.ToBandIcon();
            }
         
        }
    }
