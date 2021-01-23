    class TekkitServerSettings
    {
      private readonly static Dictionary<string, Action<TekkitServerSettings, string>> 
        _settingSetters = 
        new Dictionary<string, Action<TekkitServerSettings, string>>()
        {
          { "generator-settings=", (s, v) => s.GeneratorSettings = v },
          { "op-permission-level=", (s, v) => s.OpPermissionLevel = int.Parse(v) }
        };
    
      public string GeneratorSettings { get; set; }
      public int OpPermissionLevel { get; set; }
    }
