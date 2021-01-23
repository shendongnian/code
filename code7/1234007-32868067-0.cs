    var section = db.Sections
                    .Where(s => s.ID == SectionID)
                    .Select(s => new
                    {
                       s.Type,
                       s.Route
                     })
                    .SingleOrDefault();
    var LinkData = new [] {section.Type, section.Route};
