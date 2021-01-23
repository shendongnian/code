    Dictionary<string, string> allFieldLengths = File.ReadLines("path")
        .SkipWhile(l => !l.TrimStart().StartsWith("Field Name")) // skips lines that don't start with "Field Name"
        .Skip(1)                                       // go to next line
        .SkipWhile(l => string.IsNullOrWhiteSpace(l))  // skip following empty line(s)
        .Select(l =>                                   
        {                                              // anonymous method to use "real code"
            var line = l.Trim();                       // remove spaces or tabs from start and end of line
            string[] token = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            return new { line, token };                // return anonymous type from 
        })
        .Where(x => x.token.Length == 2)               // ignore all lines with more than two fields (invalid data)
        .Select(x => new { FieldName = x.token[0], Length = x.token[1] })
        .GroupBy(x => x.FieldName)                     // groups lines by FieldName, every group contains it's Key + all anonymous types which belong to this group
        .ToDictionary(xg => xg.Key, xg => string.Join(",", xg.Select(x => x.Length)));
