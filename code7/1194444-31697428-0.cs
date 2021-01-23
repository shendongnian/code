       public static class CounterpartExtensions
        {
            public static IEnumerable<Counterpart> SearchWithRank(this IEnumerable<Counterpart> source, string pattern)
            {
                Stopwatch sw = Stopwatch.StartNew();
                var rankedItems = new List<CounterPartRanking>();
                foreach (Counterpart counterpart in source)
                {
                    if ((counterpart.Code != null) && (counterpart.Code == pattern))
                    {
                        rankedItems.AddRange(new CounterPartRanking { Rank = 1, CounterPart = counterpart });
                    }
                    else
                    {
                        if ((counterpart.Code != null) && (counterpart.Code.StartsWith(pattern)))
                        {
                            rankedItems.AddRange(new CounterPartRanking { Rank = 2, CounterPart = counterpart });
                        }
                        else
                        {
                            if ((counterpart.Code != null) && (counterpart.Code.Contains(pattern) == pattern))
                            {
                                rankedItems.AddRange(new CounterPartRanking { Rank = 3, CounterPart = counterpart });
                            }
                        }
                    }
                   if ((counterpart.Description != null) && (counterpart.Description.Contains(pattern) == pattern))
                    {
                        rankedItems.AddRange(new CounterPartRanking { Rank = 4, CounterPart = counterpart });
                    }
                   if ((counterpart.Aliases != null) && (counterpart.Aliases == pattern))
                   {
                       rankedItems.AddRange(new CounterPartRanking { Rank = 5, CounterPart = counterpart });
                   }
                   else
                   {
                       if ((counterpart.Aliases != null) && (counterpart.Aliases.StartsWith(pattern)))
                       {
                           rankedItems.AddRange(new CounterPartRanking { Rank = 6, CounterPart = counterpart });
                       }
                       else
                       {
                           if ((counterpart.Aliases != null) && (counterpart.Aliases.Contains(pattern)))
                           {
                               rankedItems.AddRange(new CounterPartRanking { Rank = 7, CounterPart = counterpart });
                           }
                       }
                   }
                }
                sw.Stop();
                Debug.WriteLine("Time elapsed {0} for {1}", sw.Elapsed, pattern);
                var items = rankedItems.OrderBy(x => x.Rank).Select(x => x.CounterPart);
                var distinct = items.Distinct();
                return distinct;
            }
        }
