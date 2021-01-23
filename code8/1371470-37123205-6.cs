    Model badModel = null;
    var result = badModel?.Result ?? default;
    var pre72 = badModel.Result ?? default(int);
    Console.WriteLine(result); // 0
    Console.WriteLine(result.GetType().Name); // Int32
