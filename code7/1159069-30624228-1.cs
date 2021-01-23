    class Program {
        static void Main(string[] args) {
            SortedSet<MyKey> list = new SortedSet<MyKey>() {
                 new MyKey(0, 0, new DateTime(2015, 6, 4)),
                new MyKey(0, 1, new DateTime(2015, 6, 3)),
                new MyKey(1, 1, new DateTime(2015, 6, 3)),
                new MyKey(0, 0, new DateTime(2015, 6, 3)),
                new MyKey(1, 0, new DateTime(2015, 6, 3)),
               
            };
            foreach(var entry in list) {
                Console.WriteLine(string.Join(", ", entry.X, entry.Y, entry.Date));
                
            }
            Console.ReadKey();
        }
    }
