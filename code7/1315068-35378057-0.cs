    public IEnumerable<LocalizationKeyWithMissingCodes> GetAllKeysWithMissingCodes(
        List<Language> languages,
        List<Localization> localizations)
    {
        return localizations
            .GroupBy(x => x.Key, (key, items) => new LocalizationKeyWithMissingCodes
            {
                Key = key,
                MissingCodes = languages
                    .GroupJoin( // check if there is one or more match for each language
                        items,
                        x => x.Id,
                        y => y.LanguageId, (x, ys) => ys.Any() ? null : x)
                    .Where(x => x != null) // eliminate all languages with a match
                    .Select(x => x.Code) // grab the code
            })
            .Where(x => x.MissingCodes.Any()); // eliminate all complete keys 
    }
