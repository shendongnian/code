    string str = "{{Lorem Ipsum|bold}}";
    string path = ConfigurationManager.AppSettings["path"];
    var formattedString = Regex.Replace(str, @"{{(?<symbol>[^|]+?)\|(?<formats>.+?)}}", m =>
    {
        var formatedPattern = m.Groups["formats"].Value.Split(',').Aggregate("{0}", (acc, f) =>
        {
            switch (f.ToLower())
            {
                case "bold": return "<b>" + acc + "</b>";
                case "red": return "<font color = \"red\">" + acc + "</font>";
                case "blue": return "<font color = \"blue\">" + acc + "</font>";
            };
            Uri uriResult;
            if (Uri.TryCreate(f.ToLower(), UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp)
            {
                return "<a href = \"" + f + "\" target = \"_blank\">" + acc + "</a>";
            }
            else if (System.IO.File.Exists(path + f))
            {
                string fileName = System.IO.Path.GetFileName(path + f);
                return "<a href = \" \\s\\Download\\" + fileName + "\">" + acc + "</a>";
            }
            return acc;
        });
        return string.Format(formatedPattern, m.Groups["symbol"].Value);
    });
