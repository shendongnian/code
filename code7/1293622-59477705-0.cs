     private const string _englishCultureName = "en-us";
        public string GetPuralTableName(string singularTableName)
        {
            // pluralization only suported in English.
            return PluralizationService.CreateService(CultureInfo.GetCultureInfo(_englishCultureName)).Pluralize(singularTableName);
        }
