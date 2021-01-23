    foreach (var dataContainer in data)
    {
        if (dataContainer.index == match)
        {
            foreach (var item in dataContainer.DataValues)
            {
                Debug.Print(item.name + " " + string.Join(",", item.IntegerValues));
            }        
        }
    }
