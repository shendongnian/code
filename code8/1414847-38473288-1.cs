    string lastLine = multiLineData.Split(
               new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                                  .LastOrDefault();
    
    string lastWord = lastLine == null ? null : lastLine.Split(' ').FirstOrDefault();
