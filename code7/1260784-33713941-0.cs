    static void AddMoney(data myData)
    {
        myData.Money += 10;
    }
    ...
    data someData = new data { Money = 12.01m };
    AddMoney(someData);
    // someData.Money will be 22.01 now.
