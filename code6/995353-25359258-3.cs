    var languages = TextBoxLanguagesKnown.Text.Split('\n');
    // Removes deleted languages.
    var deletedLanguages = objUser.LanguageDetails.Where(ld => !languages
        .Any(l => ld.Language == l.Trim()).ToArray();
    foreach(var deletedLanguage in deletedLanguages)
    {
        objUser.LanguageDetails.Remove(deletedLanguage);
        Context.GetTable<LanguageDetail>().Remove(deletedLanguage);
    }
    // Adds new languages.
    var newLanguages = languages.Where(l => !objUser.LanguageDetails
        .Any(ld => ld.Language == l.Trim()).ToArray();
    foreach (string newLanguage in newLanguages)
    {
        var languageDetail = new LanguageDetail
        {
            Emp_Id = objUser.Emp_Id,
            Language = newLanguage.Trim()
        };
        objUser.LanguageDetails.Add(languageDetail);
    }
    Context.SubmitChanges();
