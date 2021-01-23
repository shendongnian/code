    // Some people1 and people2 lists of models already exist:
    var sw = Stopwatch.StartNew();
    var removeThese = people1.Select(x=>Tuple.Create(x.FirstName,x.LastName));
    var dic2 = people2.ToDictionary(x=>Tuple.Create(x.Name,x.Surname),x=>x);
    var result =  dic2.Keys.Except(removeThese).Select(x=>dic2[x]).ToList();
    Console.WriteLine(sw.Elapsed);
