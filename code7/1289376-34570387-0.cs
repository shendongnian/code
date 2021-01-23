        class Program
        {
            static void Main(string[] args)
            {
                Random random = new Random();
    
                int i = 0, j = 0;
                int a = 0;
                Holder prev = new Holder(null);
                Holder prev2 = new Holder(null);
    
                while (GC.CollectionCount(1) == 0)
                {
                    int aux = GC.CollectionCount(0);
                    if (aux > a)
                    {
                        a = aux;
                        ++j;
                        Console.WriteLine((i + 1));
                    }
                    ++i;
                    var flag = random.Next(1) == 1;
                    Holder h = new Holder(flag ? prev : prev2);
                    Console.WriteLine("Prev: " + GC.GetGeneration(prev));
                    Console.WriteLine("Prev2: " + GC.GetGeneration(prev2));
    
                    if (flag)
                    {
                        prev = h;
                    }
                    else
                    {
                        prev2 = h;
                    }
                }
            }
        }
    
        internal class Holder
        {
            private Holder holder;
    
            public Holder(Holder o)
            {
                holder = o;
            }
        }
