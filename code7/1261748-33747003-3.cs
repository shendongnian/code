    char[] charsToTrim = new char[]{'0','1','2','3','4','5','6','7','8','9'};
    List<string> orderedFiles = 
        Directory.EnumerateFiles(ImagesPath)
        // need a copy of the string without the extension or trailing digits
        .Select(str => new { Orig = str, Name = Path.GetFileNameWithoutExtension(str) })
        // anonymous type containing original name, just the text part and just digit part
       .Select(tmp => new { Orig = tmp.Orig, Text = tmp.Name.TrimEnd(charsToTrim), 
                Digits = tmp.Name.Replace(tmp.Name.TrimEnd(charsToTrim), "") })
        // order by the text part
        .OrderBy(tmp => tmp.Text)
        // then by the string digits parsed as int (if no digits, use -1)
        .ThenBy(tmp => tmp.Digits.Any() ? int.Parse(tmp.Digits) : -1)
        // go back to original name
        .Select(tmp => tmp.Orig)
        // return as list
        .ToList();
