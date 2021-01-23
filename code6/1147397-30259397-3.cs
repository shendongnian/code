    @{
                    var testdata = Request["TestData"];
                    var expression = Request["RegexPattern"];
                    string regexMatchResult = "No Match";
                    string dateMatchResult = "No Match";
    
                    if (!string.IsNullOrEmpty(testdata) || !string.IsNullOrEmpty(expression))
                    {
                        bool regexMatch =
                            System.Text.RegularExpressions.Regex.IsMatch(testdata, expression, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                        bool dateMatch = false;
    
                        foreach (var item in System.Text.RegularExpressions.Regex.Matches(testdata, expression))
                        {
                            dateMatch = string.Compare(item.ToString(), testdata, true) == 0;
                        }
    
                        regexMatchResult = regexMatch ? "RegEx Match" : "No Match";
                        dateMatchResult = dateMatch ? "Date Matches" : "No Match";
                    }
                  }
