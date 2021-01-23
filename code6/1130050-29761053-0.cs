    private string ReadBasicTags(string filename)
    {
      string foundTags = string.Empty;
      using (Image inputImage = new Bitmap(filename))
      {
        try
        {
          PropertyItem basicTag = inputImage.GetPropertyItem(40094); // Hex 9C9E
          if (basicTag != null)
          {
            foundTags = Encoding.Unicode.GetString(basicTag.Value).Replace("\0", string.Empty);
          }
        }
        // ArgumentException is thrown when GetPropertyItem(int) is not found
        catch (ArgumentException)
        {
          // finalOutput = "Tags not found";
        }
      }
      return foundTags;
    }
