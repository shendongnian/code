    private async Task<Dictionary<string, Bitmap>> LoadImagesAsync(List<string> urls)
    {
      Bitmap[] result = await Task.WhenAll(urls.Select(url => GetImageAsync(url)));
      return Enumerable.Range(0, urls.Length).ToDictionary(i => urls[i], i => result[i]);
    }
