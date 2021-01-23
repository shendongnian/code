    IEnumerable<EKGTypes> items = context.EKGTypes
                                         .ToList()
                                         .Select(c => MapEntity(c))
                                         .OrderBy(c => c.DisplayOrder ?? int.MaxValue)
                                         .ToList();
