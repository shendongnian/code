    public class DeviceFactory {
      // This is the factory method
      public static DeviceVersion GetDevice(DeviceType type) {
        switch (type) {
          case DeviceType.Switcher:
            return new Switcher();
          case DeviceType.Receiver:
            ...
          default:
            ...
        }
      }
    }
