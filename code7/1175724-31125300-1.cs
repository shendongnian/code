    return context.Tables
        .Where(predicate)
        .GroupBy(x => x.Y)
        .Select(t => new TableViewModel()
        {
            Name = t.FirstOrDefault().Name,
            Question = t.FirstOrDefault().Question,
            Base = t.FirstOrDefault().Base,
            Categories = t.FirstOrDefault().Categories.Select(category => new CategoryView() { Name = category.Name, ColSpan = category.ColSpan }).ToList(),
            Demographics = t.FirstOrDefault().Demographics.Select(demographic => new DemographicView() { Name = demographic.Value }).ToList(),
            Trailers = t.FirstOrDefault().Trailers.Select(trailer => new TrailerView() { Name = trailer.Value }).ToList(),
            Matrices = new MatrixView() 
            { 
                Matrix = t.Select(x => new MatrixView { Value = x.Value == "****" ? " " : x.Value }).ToList() 
            }
        }).ToList();
