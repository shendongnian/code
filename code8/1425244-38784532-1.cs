            var list = new List<int[]>();
            list.Add(new int[] { 1, 2, 3, 4 });
            list.Add(new int[] { 5, 4, 2, 1 });
            list.Add(new int[] { 5, 9, 3, 5 });
            var addArrayValues = new Func<int[], int[], int[]>(
                (source, destination) =>
                {
                    for (int i = 0; i < source.Length; i++)
                        destination[i] += source[i];
                    return destination;
                });
            var aggregateResult = list.Aggregate(new int[4],
                (accumulator, current) => addArrayValues(current, accumulator));
