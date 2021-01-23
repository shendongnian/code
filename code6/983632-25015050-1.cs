    List<Entry> entries = new List<Entry>
    {
        new Entry(05468, 0, 0),
        new Entry(12420, 1, 1),
        new Entry(08186, 2, 1),
        new Entry(03926, 3, 1),
        new Entry(93650, 2, 2),
        new Entry(07642, 3, 1),
        new Entry(16569, 2, 3),
        new Entry(49397, 1, 2),
        new Entry(93093, 1, 3),
        new Entry(36250, 2, 1)
    };
    Node node = BuildHierarchy(entries);
