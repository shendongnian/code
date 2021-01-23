     _model.Terrtories
           .GroupBy(i => i.ParentID.Value)  
           .ToDictionary(g => g.Key,   // outer dictionary key
                         g => g.ToDictionary(i => i.ID,   // inner dictionary key
                                             i => i.Namel));  // inner dictionary value
