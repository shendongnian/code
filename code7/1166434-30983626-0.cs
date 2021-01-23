    public class EventArgs<T> : EventArgs
    {
        public EventArgs(T value)
        {
            this.Value = value;
        }
    
        public T Value { get; set; }
    }
    
    public class EventArgs2 : EventArgs
    {
        public int Value { get; set; }
    }
    
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Singleton.Instance.MyEvent += (sender, e) => Console.WriteLine("MyEvent with empty parameter");
            Singleton.Instance.MyEvent2 += (sender, e) => Console.WriteLine("MyEvent2 with parameter {0}", e.Value);
            Singleton.Instance.MyEvent3 += (sender, e) => Console.WriteLine("MyEvent3 with parameter {0}", e.Value);
    
            Singleton.Instance.Call();
    
            Console.Read();
        }
    }
    
    public sealed class Singleton
    {
        private static readonly Lazy<Singleton> lazy = new Lazy<Singleton>(() => new Singleton());
    
        public static Singleton Instance { get { return lazy.Value; } }
    
        /// <summary>
        /// Prevents a default instance of the <see cref="Singleton"/> class from being created.
        /// </summary>
        private Singleton()
        {
        }
    
        /// <summary>
        /// Event without any associated data
        /// </summary>
        public event EventHandler MyEvent;
    
        /// <summary>
        /// Event with a specific class as associated data
        /// </summary>
        public event EventHandler<EventArgs2> MyEvent2;
    
        /// <summary>
        /// Event with a generic class as associated data
        /// </summary>
        public event EventHandler<EventArgs<int>> MyEvent3;
    
        public void Call()
        {
            if (this.MyEvent != null)
            {
                this.MyEvent(this, EventArgs.Empty);
            }
    
            if (this.MyEvent2 != null)
            {
                this.MyEvent2(this, new EventArgs2 { Value = 12 });
            }
    
            if (this.MyEvent3 != null)
            {
                this.MyEvent3(this, new EventArgs<int>(12));
            }
    
            Console.Read();
        }
    }
