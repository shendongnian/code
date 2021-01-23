    public void Do()
    {
        var dataList = new List<DrivingData>();
        dataList.ForEach(d => Console.WriteLine(d.Id + d.Name + d.Age));
    }
