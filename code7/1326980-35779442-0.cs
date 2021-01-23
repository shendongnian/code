        public abstract class BaseMessageProcessor
        {
            protected Controller Controller { get; private set; }
            public BaseMessageProcessor(Controller controller)
            {
                Controller = controller;
            }
            public void Process<T>(T msg) where T : BaseMessage
            {
                if (this is IMessageProcessor<T>)
                    (this as IMessageProcessor<T>).Process(msg);
                throw new NotSupportedException();
            }
        }
