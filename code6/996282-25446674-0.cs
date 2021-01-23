     public static string SsnInjectDashes(string ssn)
                {
                    if (ssn == null)
                    {
                        return String.Empty;
                    }
                    string value = ssn;
                    Regex re = new Regex(@"(\d\d\d)(\d\d)(\d\d\d\d)");
                    if (re.IsMatch(ssn))
                    {
                        Match match = re.Match(ssn);
                        value = match.Groups[1] + "-" + match.Groups[2] + "-" + match.Groups[3];
                    }
                    return value;
                }
