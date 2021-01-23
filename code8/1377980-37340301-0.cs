    var enumMatcher = $"_{Regex.Replace(name, @"\W", "").ToLower()}";
    var enumMatch = countryEnumKeys.FirstOrDefault(e => e.ToLower() == enumMatcher);
    if (enumMatch != null)
    {
        var enumIndex = Array.IndexOf(countryEnumKeys, enumMatch);
        if (enumIndex >= 0)
        {
            var country = (Country)enumIndex;
            var nsCountry = new NetSuiteCountry
            {
                Name = baseRef.name,
                Code = baseRef.internalId,
                EnumKey = country.ToString(),
                Country = country
            };
            countries.Add(nsCountry);
        }
    }
