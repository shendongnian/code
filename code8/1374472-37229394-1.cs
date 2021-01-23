    var labelData = configList
        .GroupBy(c => c.ParentGroup)
        .ToDictionary(
            g => g.Key,
            g => g.ToDictionary(
                c => c.Label,
                c => new LabelData
                {
                    StartRange = c.StartRange,
                    EndRange = c.EndRange
                }
            )
        );
