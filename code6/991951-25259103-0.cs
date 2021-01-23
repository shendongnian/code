    SelectedTags = SelectedTags.OrderBy(t => t).ToList();
 
    var foundCodes = GetAllCodes()
                       .Where(code =>
                           code.Tags
                               .OrderBy(t => t)
                               .SequenceEqual(SelectTags))
                       .Distinct()
                       .ToList();
