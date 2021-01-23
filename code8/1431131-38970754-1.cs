    var foo= things
        .AsQueryable()
        .Where(t => t.One == "One") //or whatever your filtering condition
        .GroupBy(t => t.One)
        .Select(t => new {Key = "FirstQuery", Count = t.Count()});
	var bar = thangs
        .AsQueryable()
        .Where(t => t.Two == "Two")
        .GroupBy(t => t.Two)
        .Select(t => new {Key = "SecondQuery", Count = t.Count()});
	var deferredCount = foo.Concat(bar).ToList();
