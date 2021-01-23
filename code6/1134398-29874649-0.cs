    for (var i = 12; i + 3 < lines.Length; i += 4)
    {
        Items.Add(new ItemProperties { 
            Item = lines[i],
            Description = lines[i + 1],
            Quantity = lines[i + 2],
            UnitPrice = lines[i + 3]
        });
    }
