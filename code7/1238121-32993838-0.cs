    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        public class SomeEventArgs : EventArgs
        {
            public SomeEventArgs(int value)
            {
                Value = value;
            }
            public int Value { get; }
        }
        internal class Program
        {
            public delegate void SomeEventHandler(SomeEventArgs e);
            public event SomeEventHandler SomeEvent;
            private void run()
            {
                // Start thread used to raise events.
                Task.Run(() => eventRaiser());
                // Subscribe to my own event (this just for demonstration purposes!)
                this.SomeEvent += Program_SomeEvent;
                // Raise 1000 events.
                for (int i = 0; i < 1000; ++i)
                    OnSomeEvent(i);
                // Signal that the queue is not going to get any new items.
                _queue.CompleteAdding();
                // Wait a couple of seconds.
                Thread.Sleep(2000);
                Console.WriteLine("Done.");
            }
            private void Program_SomeEvent(SomeEventArgs e)
            {
                Console.WriteLine(e.Value);
            }
            private void OnSomeEvent(int value)
            {
                _queue.Add(new SomeEventArgs(value));
            }
            private void eventRaiser()
            {
                foreach (var item in _queue.GetConsumingEnumerable())
                    SomeEvent?.Invoke(item);
                Console.WriteLine("Exiting from eventRaiser()");
            }
            private static void Main()
            {
                new Program().run();
            }
            private BlockingCollection<SomeEventArgs> _queue = new BlockingCollection<SomeEventArgs>();
        }
    }
