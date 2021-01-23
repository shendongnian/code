    public string HGSearchNew(HolidayFeedService.PackageHolidays.SearchCriteria objsearchcriteria)
    {
        XmlDocument xdoc = new XmlDocument();
        XmlNodeList ndepartures = xdoc.SelectNodes("Destinations/Departure");
        string[] departureTokens = objsearchcriteria.DepartureAirport.Split('|');
        var matches = ndepartures.Cast<XmlNode>()
            .Select(node => node.Name)
            .Intersect(departureTokens, StringComparer.InvariantCultureIgnoreCase);
        return string.Join("|", matches);
    }
