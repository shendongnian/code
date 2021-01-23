    var input = @" [SuppressMessage(""Microsoft.Globalization"", ""CA1303: Do not pass literals as localized parameters"",
            MessageId = ""YouSource.DI.Web.Areas.HelpPage.TextSample.#ctor(System.String)"",
            Justification = ""End users may choose to merge this string with existing localized resources."")]
        [SuppressMessage(""Microsoft.Naming"", ""CA2204:Literals should be spelled correctly"",
            MessageId = ""bsonspec"",
            Justification = ""Part of a URI."")]
            public int Get1Number([FromBody]string name)";
    var match = Regex.Match(input, @"\w+\s+\w+\(\[FromBody\]\w+\s+\w+\)");
    var text = match.Groups[0].Value;
