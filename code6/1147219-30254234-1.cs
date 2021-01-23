    var categories = tovRDb.MyObjects.AsEnumerable().Where(t => myHashSet.Contains(t.Id));
    var catsGrouped = categories.SelectMany(
        x => x.Specializations, // Specializations is an IEnumerable<Specialization>
        (x, y) => new
        {
            Category = x,
            Specialization = y,
        }).GroupBy(x => x.Specialization, x => x.Category)
        .ToArray();
