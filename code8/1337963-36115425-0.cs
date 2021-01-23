    Dictionary<string, Dictionary<string, int>> usedCars = new Dictionary<string, Dictionary<string, int>>();
    for(int i=0; i<UsedCars.GetLength(0); i++)
    {
        string brand = UsedCars[i, 0].ToString();
        string color = UsedCars[i, 1].ToString();
        int quantity = (int)UsedCars[i,2];
        if (!usedCars.ContainsKey(brand))
            usedCars.Add(brand, new Dictionary<string, int>());
        if (usedCars[brand].ContainsKey(color))
            usedCars[brand][color] += quantity;
        else
            usedCars[brand][color] = quantity;
    }
