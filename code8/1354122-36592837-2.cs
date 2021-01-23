    public static IEnumerable<Tuple<int, int>> GetIndexes(Transition[][] Items, char SearchChar)
    {
        for (int i = 0; i < Items.Length; i++)
        {
            for (int j = 0; j < Items[i].Length; j++)
            {
                if (Items[i][j].charItem == SearchChar) // charItem  is the name of your property
                {
                    yield return new Tuple<int, int>(i, j);
                }
            }
        }
    }
