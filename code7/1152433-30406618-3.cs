    void AppIsQuitting()
    {
        if (IsParsingSuccessful)
        {
            SaveSomething(listOfObjects, xmlPath);
        }
    }
