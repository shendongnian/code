    string [] lineprev = new string[]{"",""} ;
    while (!reader.EndOfStream)
    {
        var line = reader.ReadLine();
        if (line.Contains("X"))
        {
            // Processing : Find info in lineprev[1]
        }
        lineprev[1]=lineprev[0] ;
        lineprev[0]= line ;
    }
