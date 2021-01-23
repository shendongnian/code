    var list = new List<List<object>>();
    list.Add(new List<object>() { 1, 2, 3 });
    list.Add(new List<object>() { "a", "b", "c" });
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
