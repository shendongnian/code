    public bool ShowConfigB
    {
        get
        {
          return (Config.GetType() == typeof(ConfigType2));
        }
    }
