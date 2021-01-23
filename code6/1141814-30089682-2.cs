    currentTime = DateTime.Now.ToString();
    for (int i = 0; i < OwnersTable.Rows.Count; i++) {
        object[] items = OwnersTable.Rows[i].ItemArray;         
        if (items[9].ToString() == string.Empty) {            
            items[9] = currentTime
            OwnersTable.Rows[i].ItemArray = items;
        }
    }
