    var bigData = new BigDataClass();
    bigData.Data.Add("Some String");
    var l2 = new List<string>();
    l2.Add("String 1");
    l2.Add("String 2");
    bigData.Data = l2;
    Console.WriteLine(bigData.Data[0]);
