    foreach (string scriptLine in scriptLines)
                {
                    string line = Strip(scriptLine);
                    if (string.IsNullOrEmpty(line) || Regex.Match(line, @"^\s+$").Success)
                    {
                        continue;
                    }
    
                    Map[] RegExes =
                    {
                        new Request(), 
                        new SetUserName(), 
                        new SetPassword(), 
                        new RunRequest()
                    };
    
                    foreach (Map map in RegExes)
                    {
                        map.Match(line);
                        if (map.Success)
                        {
                            codeList.AddRange(map.CodeLines);
                            break;
                        }
                    }
                } 
