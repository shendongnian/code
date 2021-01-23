    using MassTransit;
    using NUnit.Framework;
    using System.Threading.Tasks;
    namespace MassTransitTests
    {
        public class Message
        {
        }
        public class MessageConsumer : IConsumer<Message>
        {        
            public static int TargetConsumedCount
            {
                get { return _targetConsumedCount; }
                set
                {
                    lock (_lock)
                    {
                        _targetConsumedCount = value;
                        CheckTargetReached();
                    }
                }
            }
            private static void CheckTargetReached()
            {
                if (_consumedCount >= TargetConsumedCount)
                {
                    _targetReached.SetResult(true);
                }
            }
            public static Task<bool> TargetReached { get; private set; }
            private static int _consumedCount;
            private static int _targetConsumedCount;
            private static TaskCompletionSource<bool> _targetReached;
            private static object _lock;
            static MessageConsumer()
            {
                _lock = new object();
                _targetReached = new TaskCompletionSource<bool>();
                TargetReached = _targetReached.Task;
            }
            public Task Consume(ConsumeContext<Message> context)
            {
                lock (_lock)
                {
                    _consumedCount++;
                    CheckTargetReached();
                }
                return Task.FromResult(0);
            }
        }
        [TestFixture]
        public class MassTransitTest
        {
            [Test]
            public async Task BasicTestAsync()
            {
                // Arrange
                var control = Bus.Factory.CreateUsingInMemory(configure =>
                {
                    configure.ReceiveEndpoint("myQueue", endpoint =>
                    {
                        endpoint.Consumer<MessageConsumer>();
                    });
                });
             
                using (var handle = control.Start())
                {
                    await handle.Ready; // [1]
                    // Act
                    await control.Publish(new Message());
                    await control.Publish(new Message());
                    // Assert
                    MessageConsumer.TargetConsumedCount = 2;
                    await MessageConsumer.TargetReached; // [2]
                }               
            }
        }
    }
