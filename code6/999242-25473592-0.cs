        static void Main(string[] args)
        {
            int test = 5;
            Task<Singleton>[] arr =
            { 
                Task<Singleton>.Factory.StartNew(() => Singleton.Instance),
                Task<Singleton>.Factory.StartNew(() => Singleton.Instance),
            };
            Task.WaitAll(arr);
            foreach (var item in arr)
            {
                Singleton s = item.Result;
                s.MyProperty = test++;
                Console.WriteLine(s.MyProperty);
            }
        }
