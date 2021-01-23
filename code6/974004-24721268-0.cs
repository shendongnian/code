    int final = 0;
    var result = list.Select(x => new
    {
        Price = x.Price,
        IsFirst = x.IsFirst,
        First = x.IsFirst ? x.Price : 0,
        Second = !x.IsFirst ? x.Price : 0,
        Final = x.IsFirst ? final+=x.Price : final-=x.Price
    }).ToList();
