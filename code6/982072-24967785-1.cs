    public override IEnumerable<int> ReadData( IEnumerable<int> data) 
    {
        a = data.Take(1).Single();
        return Data.Skip(1);
    }
    public override IEnumerable<int> ReadData( IEnumerable<int> data) 
    {
        var dataRead = data.Take(2);
        a = dataRead.First();
        b = dataRead.Skip(1).First();
        return data.Skip(2);
    }        
