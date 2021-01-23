    public IEnumerable<int> GetRange(int start, int number)
    {
        for (int i = start; i < start + number; i++)
        {
            yield return i;
        }
    }
