    var result = context.Languages.Join(context.Localizations, lang => true, 
    loc => true, (lang, loc) => new { Key = loc.Key, Code = lang.Code })
    .Except(context.Languages.Join(context.Localizations, lang => lang.Id, 
    loc => loc.LanguageId, (lang, loc) => new { Key = loc.Key, Code = lang.Code }))
    .GroupBy(r => r.Key).Select(r => new LocalizationKeyWithMissingCodes 
    { 
     Key = r.Key, 
     MissingCodes = r.Select(kc => kc.Code).ToList()
    })
    .ToList()
    .OrderByDescending(lkmc => lkmc.MissingCodes.Count())
    .ThenBy(lkmc => lkmc.Key).ToList();
