    foreach (Control item in colorPanel.Controls.OfType<Control>())
    {
        foreach(var name in myItemNames) 
        {
            if (item.Name == name)
            {
                colorPanel.Controls.Remove(item);
                item.Dispose();
                //...
