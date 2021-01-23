    string previous = items.FirstOrDefault();
    var seen = new HashSet<string>();
    seen.Add(previous);
    for (int i = 1; i < items.Count; i++)
    {
        if (previous != items[i])
        {
            if (!seen.Add(items[i]))
            {
                Console.WriteLine("This item is not grouped:" + items[i] + " at index " + i);
            }
            previous = items[i];
        }
    }
