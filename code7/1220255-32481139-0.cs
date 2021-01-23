    internal class Program {
        private static void Main(string[] args) {
            Console.WriteLine("Before: {0}", GC.GetTotalMemory(true));
            var pub = new Publisher();
            for (int i = 0; i < 1000000; i++) {
                var sub = new Subscriber(pub);
            }
            GC.Collect();
            Console.WriteLine("After: {0}", GC.GetTotalMemory(true));
            Console.ReadKey();
        }
    }
    public class Publisher {
        public EventHandler Published;
    }
    public class Subscriber {
        public Subscriber(Publisher pub) {
            pub.Published += delegate { };
        }        
    }
