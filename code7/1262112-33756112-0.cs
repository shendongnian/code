    var childrenMissingParents = possible_child.Where(
        c => !possible_parent.Any(
            p => p.Country == c.Country
         && p.Year == c.Year
         && p.Season == c.Season
         && p.SeasonType == c.SeasonType));
