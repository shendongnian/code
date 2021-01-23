    while (listBox.Items.Count > 0)
    {
        var item = listBox.Items[listBox.Items.Count -1);
        listBox.Items.RemoveAt(listBox.Items.Count -1);
        if (item is IDisposable)
        {
            ((IDisposable)item).Dispose();
        }
    
    }
