    public class Switcher : DeviceVersion {
      // Override the virtual
      public override DeviceType DeviceType { get { return DeviceType.Switcher; } }
      public bool CanPlay
      {
          get { return true; }
      }
      ...
    }
