        public static class Extensions
        {
            public static IEnumerable<T[]> Partition<T>(this IEnumerable<T> sequence, int partitionSize)
            {
                var buffer = new T[partitionSize];
                var n = 0;
                foreach (var item in sequence)
                {
                    buffer[n] = item;
                    n += 1;
                    if (n == partitionSize)
                    {
                        yield return buffer;
                        buffer = new T[partitionSize];
                        n = 0;
                    }
                }
                //partial leftovers
                if (n > 0) yield return buffer;
            }
        }
