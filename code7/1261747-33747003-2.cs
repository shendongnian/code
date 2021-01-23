    char[] charsToTrim = new char[]{'0','1','2','3','4','5','6','7','8','9'};
    List<string> orderedFiles = 
        Directory.EnumerateFiles(ImagesPath)
        // need a copy of the string without the extension
        .Select(str => new { Orig = str, Name = Path.GetFileNameWithoutExtension(str) })
        // anonymous type containing original name + just the string digits
        .Select(tmp => new { Orig = tmp.Orig, Digits = tmp.Name.Replace(tmp.Name.TrimEnd(charsToTrim), "") })
        // order by the string digits parsed as int or, if it has no digits, put it at the start
        .OrderBy(tmp => tmp.Digits.Any() ? int.Parse(tmp.Digits) : -1)
        // go back to original name
        .Select(tmp => tmp.Orig)
        // return as list
        .ToList();
