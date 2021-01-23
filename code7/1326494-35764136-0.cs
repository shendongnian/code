    foreach (var group in list.GroupBy(x => x.SourceTitle))
    {
        for (int i = 0; i < group.Count(); i++)
        {
            group.ElementAt(i).Color = palette[i % 10];                        
        }
    }
