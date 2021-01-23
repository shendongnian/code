    using System;
    using System.Threading;
    using System.Threading.Tasks.Dataflow;
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
                var queue = new ActionBlock<SomeEventArgs>(item => SomeEvent?.Invoke(item));
                // Subscribe to my own event (this just for demonstration purposes!)
                this.SomeEvent += Program_SomeEvent;
                // Raise 100 events.
                for (int i = 0; i < 100; ++i)
                {
                    OnSomeEvent(i);
                    Console.WriteLine("Raised event " + i);
                }
                Console.WriteLine("Signalling that queue is complete.");
                queue.Complete();
                Console.WriteLine("Waiting for queue to be processed.");
                queue.Completion.Wait();
                Console.WriteLine("Done.");
            }
            private void Program_SomeEvent(SomeEventArgs e)
            {
                Console.WriteLine("Handled " + e.Value);
                Thread.Sleep(1); // Simulate load.
            }
            private void OnSomeEvent(int value)
            {
                queue.Post(new SomeEventArgs(value));
            }
            private static void Main()
            {
                new Program().run();
            }
        }
    }
