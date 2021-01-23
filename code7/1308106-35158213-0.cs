    var appearsMoreThanOnce = arr
        .Distinct()
        .ToDictionary(k => k, v => Enumerable.Range(1, arr.Length)
            .Where(i => arr[i-1] == v))
        .Where(kvp => kvp.Value.Count() >= 2);
    
    foreach (var number in appearsMoreThanOnce)
        Console.WriteLine(number.Key + " appears at: " + string.Join(",", number.Value));
