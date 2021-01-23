    string input = "25459178 for: MARIA PETRUZZELLA on:  2014-05-27";
    System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(input, @"(?<Transaction>[0-9]+)\s+for:\s+(?<Customer>[a-zA-Z\- ]+)\s+on:\s+(?<Date>[0-9]{4}-[0-9]{2}-[0-9]{2})");
    string transaction = match.Groups["Transaction"].Value;
    string customer = match.Groups["Customer"].Value;
    string date = match.Groups["Date"].Value;
    DateTime dateObject;
    DateTime.TryParse(date, out dateObject);
