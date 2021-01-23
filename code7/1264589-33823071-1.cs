        int GetSumOfTree(List<List<int>> tree)
        {
            int sum = 0;
            foreach (List<int> line in tree)
            {
                line.Sort();
                int max = line[line.Count - 1];
                sum += max;
            }
            return sum;
        }
