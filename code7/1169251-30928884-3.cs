    List<Person> p = new List<Person>();
    for (int i = 0; i < Data.Length; i++)
    {
        p.Add(new Person()
        {
            Name = (string)Data[i, 0],
            State = (string)Data[i, 1],
            City = (string)Data[i, 2],
            Date = (List<int>)Data[i, 3],
            Total = (List<double>)Data[i, 4]
        });
    }
