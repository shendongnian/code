    public class Switcher : DeviceVersion {
      // Override the virtual
      public DeviceType DeviceType { get { return DeviceType.Switcher; } }
      public bool CanPlay
      {
          get { return true; }
      }
      ...
    }
