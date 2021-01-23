        static void Main(string[] args)
        {
            var container = new BlockingCollection<Item>();
            Thread writer = new Thread(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    container.Add(new Item("Item " + i));
                }
                container.CompleteAdding();
            });
            writer.Start();
            Thread[] readerThreads = new Thread[10];
            for (int i = 0; i < readerThreads.Length; i++)
            {
                readerThreads[i] = new Thread(() =>
                {
                    foreach (Item item in container.GetConsumingEnumerable())
                    {
                        Console.WriteLine(item.Name);
                    }
                });
                readerThreads[i].Start();
            }
            writer.Join();
            for (int i = 0; i < readerThreads.Length; i++)
            {
                readerThreads[i].Join();
            }
            Console.ReadLine();
        }
