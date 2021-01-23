    List<SectionWithoutCollections> sections;
    List<SubSectionWithoutCollections> subSections;
    List<Item> items;
    var subSectionsWithItems = subSections
        .GroupJoin(items, a => a.Id, b => b.SectionId, (a,b) => new SubSection
                   {
                       Id = a.Id,
                       SectionId = a.SectionId,
                       Items = b.ToArray()
                   });
    var sectionsWithItems = sections
        .GroupJoin(subSectionsWithItems, a => a.Id, b => b.SectionId, (a,b) => new { Section = a, SubSections = b })
        .GroupJoin(items, a => a.Section.Id, b => b.SectionId, (a,b) => new Section
                   {
                       Id = a.Section.Id,
                       Items = b.ToArray(),
                       SubSections = a.SubSections.ToArray()
                   });
