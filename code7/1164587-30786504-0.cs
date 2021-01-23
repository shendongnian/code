    ABCObject = ABCObject
        .Where(x => { double ignored; return double.TryParse(x => x.Text2, out ignored); }
        .GroupBy(c => c.ID)
        .Select(c => c.First())
        .ToList();
