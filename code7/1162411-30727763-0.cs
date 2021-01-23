    {
        List<int> items = listBox2.Items.select(i => int.Parse(i)).ToList();
    
        listBox2.Items.Clear();
        listBox2.Items.Add(items.OrderBy(i => i).ToArray());
    }
