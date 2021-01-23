            byte[] b1 = { 54, 87, 23, 87, 45, 67, 7, 85, 65, 65, 3, 4, 55, 76, 65, 64, 5, 6, 4, 54, 45, 6, 4 };
            byte[] b2 = { 76, 57, 65, 3, 4, 55, 76, 65, 64, 5, 6, 4, 54, 45, 8, 65, 66, 57, 6, 7, 7, 56, 6, 7, 44, 57, 8, 76, 54, 67 };
            //figure out which one is smaller, since that one will limit the range options
            byte[] smaller;
            byte[] bigger;
            if (b1.Count() > b2.Count())
            {
                bigger = b1;
                smaller = b2;
            }
            else
            {
                bigger = b2;
                smaller = b1;
            }
            // doesn't matter what order we put these in, since they will be ordered later by length
            List<Tuple<int, int>> ranges = new List<Tuple<int, int>>();
            Parallel.For(0, smaller.Count(), (i1) => {
                Parallel.For(i1 + 1, smaller.Count(), (i2) =>
                {
                    ranges.Add(new Tuple<int, int>(i1, i2));
                });
            });
            // order by length of slice produced by range in descending order
            // this way, once we get an answer, we know nothing else can be longer
            ranges = ranges.OrderByDescending(x => x.Item2 - x.Item1).ToList();
            Tuple<int, int> largestMatchingRange = new Tuple<int, int>(0, 0);
            foreach (Tuple<int, int> range in ranges)
            {
                bool match = true; // set in outer loop to allow for break
                for (int i1 = 0; i1 < bigger.Count(); i1++)
                {
                    if (bigger.Count() <= i1 + (range.Item2 - range.Item1))
                    {
                        //short cut if the available slice from the bigger array is shorter than the range length
                        continue;
                    }
                    match = true; // reset to true to allow for new attempt for each larger array slice
                    for (int i2 = range.Item1, i1Temp = i1; i2 < range.Item2; i2++, i1Temp++)
                    {
                        if (bigger[i1Temp] != smaller[i2])
                        {
                            match = false;
                            break;
                        }
                    }
                    if (match)
                    {
                        largestMatchingRange = range;
                        break;
                    }
                }
                if (match)
                {
                    break;
                }
            }
            byte[] largestMatchingBytes = smaller.Skip(largestMatchingRange.Item1).Take(largestMatchingRange.Item2 - largestMatchingRange.Item1).ToArray();
