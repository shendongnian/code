	private static void Test()
    {
        List<MethodToTest> methodList = new List<MethodToTest>
        {
            new MethodToTest{ MethodDelegate = RollNumbers},
            new MethodToTest{ MethodDelegate = RollLargeLookup},
            new MethodToTest{ MethodDelegate = RollLookupOptimizedModded},
            new MethodToTest{ MethodDelegate = RollOptimizedModdedConst},
            new MethodToTest{ MethodDelegate = RollOptimizedModded},
            new MethodToTest{ MethodDelegate = RollSimple},
            new MethodToTest{ MethodDelegate = RollSimpleHashSet},
            new MethodToTest{ MethodDelegate = RollAnotherSimple},
            new MethodToTest{ MethodDelegate = RollOptionRegex},
            new MethodToTest{ MethodDelegate = RollRegex},
            new MethodToTest{ MethodDelegate = RollEndsWith},
        };
        
        InitLargeLookup();
        Stopwatch s = new Stopwatch();
        Random rnd = new Random();
        List<int> Randoms = new List<int>();
        const int trial = 10000000;
        const int numberOfLoop = 10;
        for (int j = 0; j < numberOfLoop; j++)
        {
            Console.Out.WriteLine("Loop: " + j);
            Randoms.Clear();
            for (int i = 0; i < trial; ++i)
                Randoms.Add(rnd.Next(1, 100000));
            // Shuffle order
            foreach (MethodToTest method in methodList.OrderBy(m => new Random().Next()))
            {
                s.Restart();
                for (int i = 0; i < trial; ++i)
                    method.MethodDelegate(Randoms[i]);
                method.timeSpent.Add(s.ElapsedMilliseconds);
                Console.Out.WriteLine("\tMethod: " +method.MethodDelegate.Method.Name);
            }
        }
        File.WriteAllLines(@"C:\Users\me\Desktop\out.txt", methodList.OrderBy(m => m.timeSpent.Average()).Select(method => method.MethodDelegate.Method.Name + ": " + method.TimeStats()));
    }
