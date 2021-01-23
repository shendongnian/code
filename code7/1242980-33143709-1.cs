        string filter = textBox10.Text;
        d2ngList.Items.Clear();
        string[] names = games
            .Where(g => g.Name.Contains(filter)).Select(g => g.Name).ToArray();
        d2ngList.Items.AddRange(names);
