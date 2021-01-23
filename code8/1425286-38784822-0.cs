    void AddValue()
    {
    for(int i = 0; i < 10; i++)
        {
        ComboboxItem item = new ComboboxItem();
        item.Text = "Item " + i;
        item.Value = i;
        ModDown.Items.Add(item);
        }
    }
