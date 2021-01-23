    public void SomeMethod ()
    {
        foreach (var data in dataList)
        {
            Do(data);
        }
    }
    public void Do (DrivingData data)
    {
        Console.WriteLine(data.Id + data.Name + data.Age);
    }
