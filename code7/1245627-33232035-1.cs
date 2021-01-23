    List<string> votingcodes = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20"};
    var matchRegexes = votingcodes
        .Select(c => new Regex("^.*\\b" + c + "\\b.*$", RegexOptions.Compiled));
    var matchLookup = dtFetch.AsEnumerable()
        .ToLookup(row => matchRegexes
            .Any(r => r.IsMatch(row.Field<string>("FMSG_IN").ToUpper())));
    var matchRows = matchLookup[true];
    var noMatchRows = matchLookup[false];
    DataView dvMatch = null;
    DataView dvNoMatch = null;
    if (matchRows.Any())
        dvMatch = matchRows.CopyToDataTable().DefaultView;
    if (noMatchRows.Any())
        dvNoMatch = noMatchRows.CopyToDataTable().DefaultView;
