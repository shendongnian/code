    public string FileName
    {
      get { return fileName; }
      set
      {
        fileName = value;
        LoadFileAsync();
      }
    }
    private async Task LoadFileAsync()
    {
      try
      {
        CoverSource = ...; // "Loading" image or something.
        var image = await ...;
        CoverSource = image;
      }
      catch (Exception ex)
      {
        CoverSource = ...; // "Error" image or something.
      }
    }
