    private string GetLanguageForIsoCode(string isoCode)
        {
            if (languageToIsoCode == null)//if cache empty initialize it
            {
                InitializeLanguageCacheDictionary();
            }
            //searches inside the dictionary, look for value and then return key
            //might be bad if there are more than one value asigned to a key
            //because value does not habe to be unique
            string languageFromIsoCodeFromCache = languageToIsoCode.FirstOrDefault(item => item.Value == isoCode).Key;
            if (languageFromIsoCodeFromCache == null)
            {
                //fallback and use the German language as default
                return CultureInfo.GetCultureInfo("de").NativeName;
            }
            return languageFromIsoCodeFromCache;
        }
