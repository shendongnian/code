    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        internal static class Program
        {
            static void Main(string[] args)
            {
                int numberOfValuesToSelectFrom = 10000000;
                int numberOfValuesToSelect = 20;
                var valuesToSelectFrom = Enumerable.Range(1, numberOfValuesToSelectFrom);
            
                var selectedValues = RandomlySelectedItems
                (
                    valuesToSelectFrom, 
                    numberOfValuesToSelect, 
                    numberOfValuesToSelectFrom, 
                    new Random()
               );
                foreach (int value in selectedValues)
                    Console.WriteLine(value);
            }
            /// <summary>Randomly selects items from a sequence.</summary>
            /// <typeparam name="T">The type of the items in the sequence.</typeparam>
            /// <param name="sequence">The sequence from which to randomly select items.</param>
            /// <param name="count">The number of items to randomly select from the sequence.</param>
            /// <param name="sequenceLength">The number of items in the sequence among which to randomly select.</param>
            /// <param name="rng">The random number generator to use.</param>
            /// <returns>A sequence of randomly selected items.</returns>
            /// <remarks>This is an O(N) algorithm (N is the sequence length).</remarks>
            public static IEnumerable<T> RandomlySelectedItems<T>(IEnumerable<T> sequence, int count, int sequenceLength, Random rng)
            {
                if (sequence == null)
                    throw new ArgumentNullException("sequence");
                if (count < 0 || count > sequenceLength)
                    throw new ArgumentOutOfRangeException("count", count, "count must be between 0 and sequenceLength");
                if (rng == null)
                    throw new ArgumentNullException("rng");
                int available = sequenceLength;
                int remaining = count;
                var iterator  = sequence.GetEnumerator();
                for (int current = 0; current < sequenceLength; ++current)
                {
                    iterator.MoveNext();
                    if (rng.NextDouble() < remaining/(double)available)
                    {
                        yield return iterator.Current;
                        --remaining;
                    }
                    --available;
                }
            }
        }
    }
                                            
