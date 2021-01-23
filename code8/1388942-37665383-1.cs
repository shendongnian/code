    private List<Task<byte[]>> DownloadTasks(string data)
    {
      var result = new List<Task<byte[]>>();
      string[] lines = data.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
      if (!lines.Any() || lines[0] != "#EXTM3U")
        throw new Exception("Invalid m3u8 media playlist.");
      ...
               if (_isNewSegment)
               {
                 result.Add(DownloadTsSegmentAsync(line));
               }
      ...
      return result;
    }
