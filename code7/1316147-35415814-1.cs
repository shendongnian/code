    // Add an index to specify the array offset
    int index = 0;
    // The Distinct() will cause issues finding the correct array offset.
    // You may need to use GroupBy() or another mechanism to group the
    // column with the size.
    foreach (string s in Items.Select(i => i.Size).Distinct())
    {
        columns.Add(new DataGridTextColumn()
        {
            Header = s,
            // The array index must exist already. You can put a check for it above if needed.
            Binding = new Binding(string.Format("Sizes[{0}].Item2", index)),
        });
        index++;
    }
