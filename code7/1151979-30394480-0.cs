    public string ParseRandomOptionsString(string input)
    {
        var random = new Random();
        var output = string.Empty;
        var currentOption = string.Empty;
        var currentOptions = new List<string>();
        var optionsStarted = false;
        foreach (var c in input)
        {
            if (optionsStarted)
            {
                if (c == '}')
                {
                    optionsStarted = false;
                    if (!string.IsNullOrEmpty(currentOption))
                        currentOptions.Add(currentOption);
                    output += currentOptions[random.Next(currentOptions.Count)];
                    currentOptions.Clear();
                    currentOption = null;
                }
                else if (c == '|')
                {
                    if (!string.IsNullOrEmpty(currentOption))
                        currentOptions.Add(currentOption);
                    currentOption = null;
                }
                else
                {
                    currentOption += c;
                }
            }
            else
            {
                if (c == '{')
                {
                    optionsStarted = true;
                }
                else
                {
                    output += c;
                }
            }
        }
        return output;
    }
    
