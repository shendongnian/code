    ArrayList ArrayEx = new ArrayList();
    foreach (var item in _params)
    {
        ArrayEx.Add(item.Value);
    }
    
    // or like this
    
    ArrayEx.AddRange(_params.Select(x=>x.Value).ToList());
