    public static class MessengerHelper
    {
        public static IMessenger Messenger { get { return GalaSoft.MvvmLight.Messaging.Messenger.Default; } }
        public static object Group1Token { get { return 1; } }
        public static object Group2Token { get { return 2; } }
    }
    public class FooChild
    {
        object token;
        public FooChild(object token)
        {
            this.token = token;
            MessengerHelper.Messenger.Register<IFooMessage>(this, token, HandleFooMessage);
        }
        void HandleFooMessage(IFooMessage fooMessage)
        {
            Console.WriteLine("FooChild got the message, token = " + (token ?? "(null)"));
        }
    }
    public class FooParent
    {
        FooChild[] children;
        public FooParent()
        {
            children = new [] { 
                new FooChild(MessengerHelper.Group1Token),
                new FooChild(MessengerHelper.Group2Token),
                new FooChild(null)
            };
        }
        public void SendFooMessage(IFooMessage fooMessage, object token)
        {
            MessengerHelper.Messenger.Send(fooMessage, token);
        }
    }
