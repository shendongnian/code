    private void Update(Item newItem) {
        bool found = false;
        foreach (Item item in items) {
            if (newItem.Name == item.Name) {
                item.Quantity += newItem.Quantity;
                found = true;
                break;
            }
        }
        if (!found) {
            items.Add(newItem);
        }
        listBox1.DataSource = null;
        listBox1.DataSource = items;
    }
