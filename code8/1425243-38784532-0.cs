            var list = new List<int[]>();
            list.Add(new int[] { 1, 2, 3, 4 });
            list.Add(new int[] { 5, 4, 2, 1 });
            list.Add(new int[] { 5, 9, 3, 5 });
            var resultOfAggregate = new int[4];
            list.Aggregate(resultOfAggregate,
                (accumulator, current) =>
                {
                    for (int i = 0; i < current.Length; i++)
                    {
                        accumulator[i] += current[i];
                    }
                    return accumulator;
                });
            //result must be : { 11, 15, 8, 10 }
