    var result = context.Languages.Join(context.Localizations, lang => true, 
    loc => true, (lang, loc) => new { Key = loc.Key, Code = lang.Code })
    .Except(  context.Languages.Include(l => l.Localization)
    .Select(l => new { Key = l.Localization.Key, Code = l.Code }))
    .GroupBy(r => r.Key).Select(r => new LocalizationKeyWithMissingCodes 
    { 
     Key = r.Key, 
     MissingCodes = r.Values.ToList()
    })
    .ToList()
    .OrderByDescending(lkmc => lkmc.MissingCodes.Count())
    .ThenBy(lkmc => lkmc.Key).ToList();
