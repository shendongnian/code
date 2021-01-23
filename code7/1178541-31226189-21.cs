    public interface IIncomingMessage
    {
        DeviceTypeEnum DeviceType { get; }
    }
    public class IncomingFooMessage : IIncomingMessage
    {
        public DeviceTypeEnum DeviceType { get { return DeviceTypeEnum.Foo; } }
    }
    public class IncomingBarMessage : IIncomingMessage
    {
        public DeviceTypeEnum DeviceType { get { return DeviceTypeEnum.Bar; } }
    }
