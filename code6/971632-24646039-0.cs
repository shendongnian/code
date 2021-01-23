        foreach (dynamic item in maindg.Items)
        {
            if ((item.FirstName = null || item.FirstName = "") && (item.LastName = null || item.LastName = "") && (item.City = null || item.City = ""))
            {
                list.Remove(item);
            }
        }
