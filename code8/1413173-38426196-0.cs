    public class Hotkeys
    {
        [JsonProperty("hotkeyOptions")]
        public HotkeyOptions HotkeyOptions { get; set; }
    }
    public class HotkeyOptions
    {
        [JsonProperty("autoSwitchHotkeyPreset")]
        public bool AutoSwitchHotkeyPreset { get; set; }
        [JsonProperty("currentHotkeySetName")]
        public string CurrentHotkeySetName { get; set; }
        [JsonProperty("hotkeySets")]
        public Dictionary<string, JObject> HotkeySets { get; set; }
    }
