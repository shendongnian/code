    var filteredCommandLineArguments = new List<string>();
    var isValueExpected = false;
    foreach (var commandLineArgument in commandLineArguments)
    {
        if (isValueExpected)
        {
           isValueExpected = false;
           filteredCommandLineArguments.Add(commandLineArgument);
           continue;
        }
        if (commandLineArgument.StartsWith("--"))
        {
           isValueExpected = true;
           filteredCommandLineArguments.Add(commandLineArgument);
        }
    }
