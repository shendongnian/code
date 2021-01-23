    const string superscriptDigits = "⁰¹²³⁴⁵⁶⁷⁸⁹";
    var digitToSuperscriptMapping = superscriptDigits.Select((c, i) => new { c, i })
                                    .ToDictionary(item => item.c, item => item.i.ToString());
    const string source = "23⁴⁴";
    var baseString = new string(source.TakeWhile(char.IsDigit).ToArray());
    var exponentString = string.Concat(source.SkipWhile(char.IsDigit).Select(c => digitToSuperscriptMapping[c]));
