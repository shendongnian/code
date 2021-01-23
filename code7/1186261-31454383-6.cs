    private static readonly ConcurrentDictionary<string, byte[]> _cache;
    Color GetPixel(string fileName, int x, int y)
    {
      var buffer = new byte[3];
      using (var file = File.OpenRead(fileName))
      {
        byte[] headers;
        if (_cache.ContainsKey(fileName))
        {
          headers = _cache[fileName];
        }
        else
        {
          headers = new byte[1078];
          if (file.Read(headers, 0, headers.Length) < headers.Length) return Color.Empty;
          _cache.TryAdd(fileName, headers);
        }
        // Now read the headers as before, using the headers local instead of buffer
        // ...
        file.Seek(offset + ((rowSize * (height - y - 1)) + x), SeekOrigin.Begin);
        if (file.Read(buffer, 0, 1) < 1) return Color.Empty;
        var color = BitConverter.ToInt32(headers, 54 + buffer[0] * 4);
        return Color.FromArgb(color);
      }
    }
