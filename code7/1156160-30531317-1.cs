        List<Item> items = new List<Item>();
        var lines = File.ReadAllLines("path-to-file");
        Item currentItem = null;
        foreach (var line in lines)
        {
            if (line.StartsWith("------->"))
            {
                if (currentItem != null)
                {
                    items.Add(currentItem);
                }
                currentItem=new Item();
                currentItem.Header = line;
            }
            else if (currentItem != null)
            {
                currentItem.Indexes.Add(line);
            }
        }
        if (currentItem!=null)
            items.Add(currentItem);
