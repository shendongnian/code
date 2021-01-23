     _model.Terrtories
           .GroupBy(i => i.ParentID.HasValue ? 0 : i.ParentID.Value)   
           .ToDictionary(g => g.Key,   // outer dictionary key
                         g => g.ToDictionary(i => i.ID,   // inner dictionary key
                                             i => i.Name));  // inner dictionary value
