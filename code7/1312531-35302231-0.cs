    var sections = new List<Section>();
            var subSections = new List<SubSection>();
            var items = new List<Item>();
            var itemSections = from s in sections
                               let i = items.Where(j => j.sectionId == s.Id).DefaultIfEmpty().ToArray()
                               let ss = subSections.Where(j => j.sectionId == s.Id).DefaultIfEmpty().ToArray()
                               select new Section
                               {
                                   Id = s.Id,
                                   SubSections = ss,
                                   Items = i
                               };
