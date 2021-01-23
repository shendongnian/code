     //BlockingCollection with a fix number of Products to put, it works with 10 items max on the collection
        class Program
        {
            private static int counter = 1;
            private static BlockingCollection<Product> products =
                new BlockingCollection<Product>(10);
    
            static void Main(string[] args)
            {
                //three producers
                Task.Run(() => Producer());
                Task.Run(() => Producer());
                Task.Run(() => Producer());
    
                Task.Run(() => Consumer());
    
                Console.ReadLine();
            }
    
            static void Producer()
            {
                while (true)
                {
                    var product = new Product()
                    {
                        Number = counter,
                        Name = "Product " + counter++
                    };
    
                    //Adding one element
                    Console.WriteLine("Producing: " + product);
                    products.Add(product);
    
                    Thread.Sleep(2000);
                }
            }
    
            static void Consumer()
            {
                while (true)
                {
                    //wait until exist one element
                    if (products.Count == 0)
                        continue;
    
                    var product = products.Take();
                    Console.WriteLine("Consuming: " + product);
    
                    Thread.Sleep(2000);
                }
            }
        }
    
        public class Product
        {
            public int Number { get; set; }
            public string Name { get; set; }
    
            public override string ToString()
            {
                return Name;
            }
        }
