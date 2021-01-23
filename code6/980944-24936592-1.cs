            Random r;
            const int repeatCount = 1000000;
            List<int> list = null;
            r = new Random(0);
            var start = DateTime.Now.Ticks;
            for (int i = 0; i < repeatCount; i++)
            {
                list = Enumerable.Repeat(0, r.Next(5,150)).ToList();
            }
            var end = DateTime.Now.Ticks;
            var t1 = end - start;
            r = new Random(0);
            start = DateTime.Now.Ticks;
            for (int i = 0; i < repeatCount; i++)
            {
                Sizer<int>.Init(ref list, r.Next(5, 150)); // fill the list with default values for the type
            }
            end = DateTime.Now.Ticks;
            var t2 = end - start;
            var speedup = (double)t1 / t2;
