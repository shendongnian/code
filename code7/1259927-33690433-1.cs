    public static Tuple<int, int> FindTwoSum(List<int> list, int sum)
    {
        for (int i=0; i<list.Count; i++)
        {
            for(int j=0; j<=i; j++)
            {
                if (list[i] + list[j] == sum)
                {
                    return Tuple.Create(j, i);
                }
            }
        }
        return null;
    }
