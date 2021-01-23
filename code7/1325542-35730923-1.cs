    var letters = new[] { "A", "B", "C", "D" };
    
    var pairs = new[]
    {
        new { Id = 1, Letter = "A" },
        new { Id = 2, Letter = "Z" },
        new { Id = 3, Letter = "F" }
    };
    
    var result = letters.GroupJoin(
        pairs, // join letters with pairs
        x => x, // use the whole letter as the matching key
        y => y.Letter, // use the Letter property as the matching key
        (x, ys) => new { Letter = x, Exists = ys.Any() }); // yield true if there are any matches, otherwise false
