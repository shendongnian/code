    using (StreamReader sr = new StreamReader(stream))
    {
        string firstLine = sr.ReadLine();
        // Check to be on the safe side....
        if(firstLine != null)
        {
             string str = sr.ReadToEnd();
             // Not sure, but it seems overkill to use a Regex just to split
             // and it is always better to use predefined constant for newline.
             string[] lines = str.Split(new string[] {Environment.NewLine}, 
                                        StringSplitOptions.RemoveEmptyEntries);
        }
    }
