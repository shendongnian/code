    for (int i = 0; i <= items.Count; i++)
    {
        for (int price = 0; price <= maxPrice; price++)
        {
            for (int count = 1; count <= maxCount; count++)
            {
                scores[i, price, count] = int.MinValue;
            }
        }
    }
