    // Get the address lines to be displayed
    string[] lines = new string[]
    {
       ticket.Address1,
       ticket.Address2,
       ticket.Address3,
       ticket.Address4,
       ticket.ZipCode,
    };
    // Remove blank lines
    IEnumerable<string> filledLines = lines.Where(s => !string.IsNullOrWhitespace(s));
    // Add newlines between each line
    string html = string.Join(@"<br />", filledLines);
