            var name = "tuckyou";
            // Lowered bad words array
            string[] badWordArray = { "abadword1", "abadword2", "abadword3" };
            Stopwatch stopwatch = new Stopwatch();
            int oneMillion = 1000000;
            bool isBadWord = false;
            stopwatch.Start();
            for (int i = 0; i < oneMillion; i++)
            {
                isBadWord = badWordArray.Any(badWord => string.Equals(name, badWord, StringComparison.CurrentCultureIgnoreCase));
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < oneMillion; i++)
            {
                isBadWord = badWordArray.Any(badWord => name.IndexOf(badWord, StringComparison.CurrentCultureIgnoreCase) >= 0);
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
            stopwatch.Start();
            if (!string.IsNullOrEmpty(name))
            {
                name = name.ToLower();
            }
            for (int i = 0; i < oneMillion; i++)
            {
                isBadWord = badWordArray.Any(badWord => name.Contains(badWord));
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.ReadLine();
