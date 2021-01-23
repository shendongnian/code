    List<int> mylist = new List<int>(new int[] { 1,2,3,4,5,6,7,8,9 });
    GetCombination(mylist);
    private static void GetCombination(IList<int> values)
    {
        for (int i = 0; i < values.Count; i++)
        {
            for (int j = 0; j < values.Count; j++)
            {
                if (i != j)
                {
                    Console.WriteLine(values[i] + " " + values[j]);
                }
            }
        }
    }
