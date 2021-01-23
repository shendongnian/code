       static void Main()
        {
            var enumerable = CreateMyVeryOwnEnumerable();
            var obs = enumerable.ToObservable();
            obs.Subscribe(o => Console.WriteLine(o));
            
            Console.ReadKey();
        }
        static IEnumerable<int> CreateMyVeryOwnEnumerable()
        {
            // non-terminating
            while (true)
                yield return 0;
            // terminating
            //return Enumerable.Range(0, 100);
        }
