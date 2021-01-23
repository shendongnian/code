    private bool TryParseHelpVerb(string[] args, object options, Pair<MethodInfo, HelpVerbOptionAttribute> helpInfo, OptionMap optionMap)
    {
        var helpWriter = _settings.HelpWriter;
        if (helpInfo != null && helpWriter != null)
        {
            if (string.Compare(args[0], helpInfo.Right.LongName, GetStringComparison(_settings)) == 0)
            {
                // User explicitly requested help
                var verb = args.FirstOrDefault(); // <----- change this to args[1];
                if (verb != null)
                {
                    var verbOption = optionMap[verb];
                    if (verbOption != null)
                    {
                        if (verbOption.GetValue(options) == null)
                        {
                            // We need to create an instance also to render help
                            verbOption.CreateInstance(options);
                        }
                    }
                }
                DisplayHelpVerbText(options, helpInfo, verb);
                return true;
            }
        }
        return false;
    }
