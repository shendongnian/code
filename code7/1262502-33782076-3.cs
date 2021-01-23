    using System;
    using System.Threading.Tasks;
    using EasyNetQ;
    using EasyNetQ.Consumer;
    using EasyNetQ.Loggers;
    using EasyNetQ.Topology;
 
    namespace ConsoleApplication4
    {
        public static class RabbitAdvancedBusConsumeExtension
        {
           public static IDisposable Consume(this IAdvancedBus bus, IQueue queue, Action<byte[], MessageProperties, MessageReceivedInfo> onMessage)
        {
            return bus.Consume(queue, (bytes, properties, info) => ExecuteSynchronously(() => onMessage(bytes, properties, info)));
        }
 
        public static IDisposable Consume(this IAdvancedBus bus, IQueue queue, Action<byte[], MessageProperties, MessageReceivedInfo> onMessage, Action<IConsumerConfiguration> configure)
        {
            return bus.Consume(queue, (bytes, properties, info) => ExecuteSynchronously(() => onMessage(bytes, properties, info)), configure);
        }
 
        private static Task ExecuteSynchronously(Action action)
        {
            var tcs = new TaskCompletionSource<object>();
            try
            {
                action();
                tcs.SetResult(null);
            }
            catch (Exception e)
            {
                tcs.SetException(e);
            }
            return tcs.Task;
        }
    }
 
    class Program
    {
        static void Main(string[] args)
        {
            var bus = RabbitHutch.CreateBus("host=localhost", x => x.Register<IEasyNetQLogger>(s => new ConsoleLogger()));
 
            var queue = bus.Advanced.QueueDeclare();
            bus.Advanced.Consume(queue, (bytes, properties, info) =>
            {
                // .....
            });
        }
    }
    }
