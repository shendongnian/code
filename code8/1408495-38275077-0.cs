    [UserScopedSetting]
    public CaptureResolution ResolutionSelection
    {
      get
      {
        var value = (CaptureResolution)this[nameof(ResolutionSelection)];
        if (value == null)
        {
          value = new CaptureResolution(1, 2);  // decent default value
          this[nameof(ResolutionSelection)] = value;
        }
        return value;
      }
      set { this[nameof(ResolutionSelection)] = value; }
    }
