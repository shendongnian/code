    [Transformable(DeviceTypeEnum.Foo)]
    public class AMessageTransformer : IMessageTransformer<AMessage>
    {
        public AMessage Transform(IIncomingMessage message)
        {
            if (!(message is IncomingFooMessage))
            {
                throw new InvalidCastException("Message was not an IncomingFooMessage");
            }
            return new AMessage();
        }
    }
    [Transformable(DeviceTypeEnum.Bar)]
    public class BMessageTransformer : IMessageTransformer<BMessage>
    {
        public BMessage Transform(IIncomingMessage message)
        {
            if (!(message is IncomingBarMessage))
            {
                throw new InvalidCastException("Message was not an IncomingBarMessage");
            }
            return new BMessage();
        }
    }
