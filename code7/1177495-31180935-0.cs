    var users = new List<Tuple<int, string, int>> {
        Tuple.Create(1, "Steve", 21),
        Tuple.Create(2, "Jack", 17),
        Tuple.Create(3, "Alice", 25),
        Tuple.Create(4, "Harry", 14)
    };
    var userInfos = new List<Tuple<int, string, string>> {
        Tuple.Create(1, "Height", "70"),
        Tuple.Create(2, "Height", "65"),
        Tuple.Create(2, "Eyes", "Blue"),
        Tuple.Create(4, "Height", "51"),
        Tuple.Create(3, "Hair", "Brown"),
        Tuple.Create(1, "Eyes", "Green"),
    };
    var query = users.GroupJoin(userInfos,
        u => u.Item1,
        ui => ui.Item1,
        (u, infos) => new { User = u, Infos = infos });
    var result = query.Select(qi => new
    {
        Id = qi.User.Item1,
        Name = qi.User.Item2,
        Age = qi.User.Item3,
        Height = qi.Infos.Where(i => i.Item2 == "Height").Select(i => i.Item3).SingleOrDefault(),
        Eyes = qi.Infos.Where(i => i.Item2 == "Eyes").Select(i => i.Item3).SingleOrDefault(),
        Hair = qi.Infos.Where(i => i.Item2 == "Hair").Select(i => i.Item3).SingleOrDefault()
    });
