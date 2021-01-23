    public class DeviceCalibration
    {
        ...
        [JsonConverter(typeof(VersionConverter))]
        public Version Version { get; set }
    }
