    // Declare the regex
    private static readonly Regex regex = new Regex(@"(\d)(?=(\d{3})+(?!\d))", RegexOptions.Compiled); 
    // Then, somewhere inside a method
    var replacement = string.Format("$1{0}", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator);  // Get the system digit grouping separator
    var strn = "Hello 34234456 where 3334 is it?"; // Just a sample string
    // Somewhere (?:inside a loop)?
    var res = regex.Replace(strn, replacement);
