    var input = "YH300s, H900H, 234, 90.5, +12D, 48E, R180S, 190A, 350A, J380S";
    var reslts = input.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                     .Where( p.Any(n => Char.IsDigit(n)) && 
                             p => double.Parse(Regex.Match(p, @"[-+]?\d+(?:\.\d+)?").Value,
                     System.Globalization.CultureInfo.GetCultureInfo("en-us")) > 125).ToList();
