    private static readonly List<string> _cultures = new List<string> {
    "listOfClutures" 
    };
        public static bool IsRighToLeft()
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.IsRightToLeft;
        }
        public static string GetImplementedCulture(string name)
        {
            if (string.IsNullOrEmpty(name))
                return GetDefaultCulture(); // return Default culture
            if (!CultureInfo.GetCultures(CultureTypes.SpecificCultures).Any(c => c.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)))
                return GetDefaultCulture(); // return Default culture if it is invalid
            if (_cultures.Any(c => c.Equals(name, StringComparison.InvariantCultureIgnoreCase)))
                return name; // accept it
            var n = GetNeutralCulture(name);
            foreach (var c in _cultures)
                if (c.StartsWith(n))
                    return c;
            return GetDefaultCulture(); // return Default culture as no match found
        }
        public static string GetDefaultCulture()
        {
            return "en-GB"; // return Default culture, en-GB
        }
        public static string GetCurrentCulture()
        {
            return Thread.CurrentThread.CurrentCulture.Name;
        }
        public static string GetCurrentNeutralCulture()
        {
            return GetNeutralCulture(Thread.CurrentThread.CurrentCulture.Name);
        }
        public static string GetNeutralCulture(string name)
        {
            if (!name.Contains("-")) return name;
            return name.Split('-')[0]; // Read first part only. E.g. "en", "es"
        }
        public static List<KeyValuePair<string, string>> GetImplementedLanguageNames()
        {
            List<KeyValuePair<string, string>> languageNames = new List<KeyValuePair<string, string>>();
            foreach (string culture in _cultures)
            {
                languageNames.Add(new KeyValuePair<string, string>(culture, CultureInfo.GetCultureInfo(culture).EnglishName));
            }
            languageNames.Sort((firstPair, nextPair) =>
            {
                return firstPair.Value.CompareTo(nextPair.Value);
            });
            string currCulture = GetCurrentCulture();
            languageNames.Remove(new KeyValuePair<string, string>(currCulture, CultureInfo.GetCultureInfo(currCulture).EnglishName));
            languageNames.Insert(0, new KeyValuePair<string, string>(currCulture, CultureInfo.GetCultureInfo(currCulture).EnglishName));
            return languageNames;
        }
        public static string GetDateTimeUsingCurrentCulture(DateTime dateToConvert)
        {
            CultureInfo ci = new CultureInfo(GetCurrentCulture());
            return dateToConvert.ToString(ci.DateTimeFormat.ShortDatePattern + ' ' + ci.DateTimeFormat.ShortTimePattern);
        }
    }
