    int iterations = 12;
    var newList = new List<byte>();
    
    for(int i = 0; i < iterations; i++)
    {
        newList.AddRange(list.Skip(40002 * i).Take(39998));
    }
    var result = newList.ToArray();
