     string find = "Savings found:";
        foreach (var line in a.Where(w => w.Contains(find)))
           {
              Regex regex = new Regex(@"Savings found:\s\$[0-9]*.[0-9]{2}\s*\([0-9]*.[0-9]{2} %\)");
              Match match = regex.Match(line);
              var savingsFoundSection = match.Value;
              
              MatchCollection matches = Regex.Matches(savingsFoundSection, @"[0-9]*\.[0-9]{2}");
              String savingsString = matches[0].Value;
              String percentString = matches[1].Value;
              var savings = double.Parse(savingsString);
              var percent = double.Parse(percentString);
    
              Console.WriteLine("{0}{1}{2}", (percent >= 30) ? "*" : string.Empty,
    
              (percent >= 30 && savings >= 500) ? "*" : string.Empty,
                                                            line);
             }
