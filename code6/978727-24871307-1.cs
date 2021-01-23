    string input = @"12345 beautiful text in line01
    95469 other text in line02
    16987 nice text in line03";
    var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
    var formattedLines = lines
        .Select(x => new
        {
            Number = int.Parse(x.Substring(0, 5)),
            Data = x.Substring(5).TrimStart()
        })
        .ToList();
