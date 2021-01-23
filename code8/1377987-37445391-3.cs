    static string getCountryEnum(string countryName)
    {
        // Create a dictionary for looking up the exceptions that can't be converted
        // Don't know what Netsuite was thinking with these ones ;D
        Dictionary<string, string> dictExceptions = new Dictionary<string, string>()
        {
            {"Congo, Democratic Republic of", "_congoDemocraticPeoplesRepublic"},
            {"Myanmar (Burma)", "_myanmar"},
            {"Wallis and Futuna", "_wallisAndFutunaIslands"}
        };
        // Replace with "'s" in the Country names with "s"
        string countryName2 = Regex.Replace(countryName, @"\'s", "s");
        // Call a function that replaces accented characters with non-accented equivalent
        countryName2 = RemoveDiacritics(countryName2);
        countryName2 = Regex.Replace(countryName2, @"\W", " ");
        string[] separators = {" ","'"}; // "'" required to deal with country names like "Cote d'Ivoire"
        string[] words = countryName2.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        for (var i = 0; i < words.Length; i++)
        {
            string word = words[i];
            if (i == 0)
            {
                words[i] = char.ToLower(word[0]) + word.Substring(1);
            }
            else
            {
                words[i] = char.ToUpper(word[0]) + word.Substring(1);
            }
        }
        string countryEnum2 = "_" + String.Join("", words);
        // return an empty string if the country name contains Deprecated
        bool b = countryName.Contains("Deprecated");
        if (b)
        {
            return String.Empty;
        }
        else
        {
            // test to see if the country name was one of the exceptions
            string test;
            bool isExceptionCountry = dictExceptions.TryGetValue(countryName, out test);
            if (isExceptionCountry == true)
            {
                return dictExceptions[countryName];
            }
            else
            {
                return countryEnum2;
            }
        }
    }
