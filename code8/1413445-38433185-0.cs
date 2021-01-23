    public static IEnumerable<IEnumerable<int>> GroupDay(IEnumerable<int> list)
        {
            List<int> input = new List<int>(list);
            while (input.Count > 0)
            {
                int i = input[0];
                var group = new List<int>();
                group.Add(i);
                input.RemoveAt(0);
                for (int j = 0; j < input.Count; )
                {
                    if (Math.Abs(group[group.Count - 1] - input[j]) == 1
                        || Math.Abs(group[0] - input[j]) == 6)
                    {
                        group.Add(input[j]);
                        input.RemoveAt(j);
                    }
                    else
                    {
                        j++;
                    }
                }
                // Sort output
                group.Sort((x, y) => {
                    if (Math.Abs(x - y) == 6)
                    {
                        // Sunday and Monday case
                        return y - x;
                    }
                    else
                        return x - y;
                });
                yield return group;
            }
        }
