    List<int> myValues = new List<int>(new int[] { 1, 3, 3, 3, 7, 7 } );
    Dictionary<int, int> repetitions = new Dictionary<int, int>(); 
    foreach (var val in myValues)
    {
        if (repetitions.ContainsKey(val))
            repetitions[val]++; // Met it one more time
        else
            repetitions.Add(val, 1); // Met it once, because it is not in dict. 
    }
    var modeRecord = repetitions.OrderByDescending(x => x.Value).First();
    Console.WriteLine("Mode is {0}. It meets {1} times in an list", modeRecord.Key, modeRecord.Value);
