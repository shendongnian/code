    /// <summary>
    /// If the arguments are in the format /member=value
    /// Than this function returns the value by the given membername (!casesensitive) (pass membername without '/')
    /// If the member is a switch without a value and the switch is preset the given ArgName will be returned, so if switch is presetargname means true..
    /// </summary>
    /// <param name="args">Console-Arg-Array</param>
    /// <param name="ArgName">Case insensitive argname without /</param>
    /// <returns></returns>
    private static string getArgValue(string[] args, string ArgName)
    {
        var singleFound = args.Where(w => w.ToLower() == "/" + ArgName.ToLower()).FirstOrDefault();
        if (singleFound != null)
            return ArgName;
        var arg = args.Where(w => w.ToLower().StartsWith("/" + ArgName.ToLower() + "=")).FirstOrDefault();
        if (arg == null)
            return null;
        else
            return arg.Split('=')[1];
    }
