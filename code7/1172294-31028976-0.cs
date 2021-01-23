    string filepath;
    string arguments = System.Environment.GetCommandLineArgs();
    if (arguments.Length >= 2)
    {
        filepath = arguments[1];
        DoYourThing(filepath);
    }
    return;
