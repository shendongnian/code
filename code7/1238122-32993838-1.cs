        using System;
        using System.Collections.Concurrent;
        using System.Threading;
        using System.Threading.Tasks;
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
                ActionBlock<SomeEventArgs> queue;
                private void run()
                {
                    queue = new ActionBlock<SomeEventArgs>(item => SomeEvent?.Invoke(item));
                    // Subscribe to my own event (this just for demonstration purposes!)
                    this.SomeEvent += Program_SomeEvent;
                    // Raise 1000 events.
                    for (int i = 0; i < 1000; ++i)
                        OnSomeEvent(i);
                    // Signal that the queue is not going to get any new items.
                    queue.Complete();
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
                    queue.Post(new SomeEventArgs(value));
                }
                private static void Main()
                {
                    new Program().run();
                }
            }
        }
