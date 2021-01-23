    var list = new List<List<object>>();
    var intList = new List<int>() { 1, 2, 3 };
    var stringList = new List<string>() { "a", "b", "c" };
    list.Add(intList.Cast<object>().ToList());
    list.Add(stringList.Cast<object>().ToList());
    
    var sum = 0;
    list[0].Cast<int>().ToList()
            .ForEach(i =>
            {
                sum += i;
            });
    var msg = "";
    list[1].Cast<string>().ToList()
            .ForEach(s =>
            {
                msg += s;
            });
