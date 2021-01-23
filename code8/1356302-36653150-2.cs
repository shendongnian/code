    LineViewModels = LinesCollection
        .Select(x => new LineViewModel 
        {
            IsAutoScale = x.AutoScale,
            Scale = x
        }
        .ToList();
