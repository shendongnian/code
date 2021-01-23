    public IEnumerable<IEnumerable<T>> GetPowerSetOfLength<T>(List<T> list, int length)
    {
        return from m in Enumerable.Range(0, 1 << list.Count)
                  let setResult = ( from i in Enumerable.Range(0, list.Count)
                                    where (m & (1 << i)) != 0
                                    select list[i]).ToList()
                  where setResult.Count==length
                  select setResult;
    }
