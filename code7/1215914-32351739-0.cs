    for (int i = intervals.Count - 1; i >= 0; i--)
    {
        if (intervals[i].Intersects(point))
        {
            intervals.RemoveAt(i);
        }
    }
