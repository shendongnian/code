            var list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            // Use extension method.
            var stp = new Stopwatch();
            stp.Start();
            bool a = list.Contains<int>(7);
            stp.Stop();
            Console.WriteLine("Time in extenstion method {0}", stp.Elapsed);
            stp.Restart();
            // Use instance method.
            bool b = list.Contains(7);
            stp.Stop();
            Console.WriteLine("Time in normal method {0}", stp.Elapsed);
