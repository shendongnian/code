    var data = db.Translator.Select(t => new
    {
        TranslatorID = t.TranslatorID,
        FirstName = t.FirstName,
        LastName = t.LastName,
        Email = t.Email,
        Languages = t.TranslatorLanguage.Select(tl => new
        {
            SourceCode = tl.Language1.Code,
            SourceDescription = tl.Language1.Description,
            TargetCode = tl.Language2.Code,
            TargetDescription = tl.Language2.Description,
        }).ToList()
    }).ToList();
 
