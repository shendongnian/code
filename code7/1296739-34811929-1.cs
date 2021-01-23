    public void BenchmarkArrayItemReplacements()
        {
            var rand = new Random();
            var arrayExisting = Enumerable.Repeat(2, 1000).ToArray();
            var arrayReplacements = Enumerable.Repeat(1, 100);
            var toReplace = Enumerable.Range(0, 100).Select(x => rand.Next(100)).ToList();
            toReplace.ForEach(x => arrayExisting[x] = -1);
            var misisngIndices = toReplace.ToArray();
            var sw = Stopwatch.StartNew();
           
            
            var result = ArrayReplacement.ReplceUsingForLoop(arrayExisting, arrayReplacements);
            Console.WriteLine($"for loop took {sw.ElapsedTicks}");
            sw.Restart();
            result = ArrayReplacement.ReplaceUsingLinq(arrayExisting, arrayReplacements);
            Console.WriteLine($"linq took {sw.ElapsedTicks}");
            sw.Restart();
            result = ArrayReplacement.ReplaceUsingLoopWithMissingArray(arrayExisting, arrayReplacements, misisngIndices);
            Console.WriteLine($"with missing took {sw.ElapsedTicks}");
            sw.Restart();
            result = ArrayReplacement.ReplaceUsingPointers(arrayExisting, arrayReplacements);
            Console.WriteLine($"Pointers took {sw.ElapsedTicks}");
           
        }
