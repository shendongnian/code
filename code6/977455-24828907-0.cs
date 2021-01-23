    var clone = context.Pages
        .AsNoTracking()
        .Including(pages => pages.Sections)
        .Single(...);
    context.Pages.Add(clone);
    context.SaveChanges(); // creates an entirely new object graph in the database
