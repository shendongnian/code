    var languages = TextBoxLanguagesKnown.Text.Split('\n');
    // Removes deleted languages (first find all language details that are missing from the UI).
    var deletedLanguages = objUser.LanguageDetails.Where(ld => !languages
        .Any(l => ld.Language == l.Trim())).ToArray();
    foreach(var deletedLanguage in deletedLanguages)
    {
        objUser.LanguageDetails.Remove(deletedLanguage);
        Context.LanguageDetails.DeleteOnSubmit(deletedLanguage);
    }
    // Adds new languages (then adds new language details that are not found in the database).
    var newLanguages = languages.Where(l => !objUser.LanguageDetails
        .Any(ld => ld.Language == l.Trim())).ToArray();
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
