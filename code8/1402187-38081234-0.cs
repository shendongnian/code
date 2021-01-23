     private static Dictionary<string, string> languageToIsoCode; //dictionary cache
     private void InitializeLanguageCacheDictionary()
        {
            using (var unitOfWork = dataAccessUnitOfWorkFactory.Create())
            {
                languageToIsoCode = (from p in unitOfWork.OwEntities.CTLANG
                                     select new {p.LANGUAGENAME, p.ISOCODE}).ToDictionary(p => p.LANGUAGENAME, p => p.ISOCODE);
            }
        }
