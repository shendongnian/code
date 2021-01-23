    bool isGerman = false;
    bool isEnglish = false;
    bool nextEntryIsFileName = false;
    string filename = null;
    foreach (string arg in args)
    {
        switch (arg)
        {
            case "-e":
                isEnglish = true;
                nextEntryIsFileName = false;
                break;
            case "-g":
                isGerman = true;
                nextEntryIsFileName = false;
                break;
            case "-f":
                nextEntryIsFileName = true;
                break;
            default:
                if (nextEntryIsFileName)
                {
                    filename = arg;
                    nextEntryIsFileName = false;
                }
                break;
        }
    }
    if (!(isEnglish ^ isGerman))
    {
        // Select language
    }
    if (String.IsNullOrEmpty(filename))
    {
        // Ask for filename
    }
    var language = ...
    FleschScore fs = new FleschScore(language, fileName);
    fs.Run();
