        var memory = FruitsDB.ToString();
       
        foreach (ListItem item in Fruits.Items)
        {
            if (memory.Contains(item.Value))
            {
                item.Enabled = false;
                item.Selected = true;
            }
        }
