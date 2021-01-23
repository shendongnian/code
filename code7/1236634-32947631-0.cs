    query = query.Where(
        x => searchArray.All(
            y => x.GroupName.Contains(y) ||            
                 x.Description.Contains(y) ||
                 x.SubGroups.Any(sg => sg.GroupName.Contains(y) ||
                 x.SubGroups.Any(sg => sg.Description.Contains(y))));                     
