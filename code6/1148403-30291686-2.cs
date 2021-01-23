    var regex = new Regex(String.Format(@"\b{0}\b", Regex.Escape(word)), RegexOptions.IgnoreCase);
    var result = String.Join(Environment.NewLine, text.Split(new String[]{ Environment.NewLine }, StringSplitOptions.None)
        /* remove line */ .Where(line => !regex.IsMatch(line))
        /* replace line */ //.Select(line => !regex.IsMatch(line) ? line : "" /* replacement*/)
        .AsEnumerable()
    ).Dump("LINQ");
