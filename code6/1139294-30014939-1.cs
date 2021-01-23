    List<int> possible = Enumerable.Range(1, 48).ToList();
    List<int> listNumbers = new List<int>();
    for (int i = 0; i < 6; i++)
    {
      int index = rand.Next(0, possible.Count);
      listNumbers.Add(possible[index]);
      possible.RemoveAt(index);
    }
