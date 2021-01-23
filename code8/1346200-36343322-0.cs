    var linesGroupedByUser =
        from line in File.ReadAllLines(path)
        let elements = line.Split(',')
        let user = new {Name = elements[0], Value = elements[1]}
        group  user by user.Name into users
        select users;
    foreach (var user in linesGroupedByUser)
    {
        string valuesAsString = String.Join(",", user.Select(x => x.Value));
        Console.WriteLine(user.Key + ", " + valuesAsString);
    }
