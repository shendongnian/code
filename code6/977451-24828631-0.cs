    public string readFile(checkSpell chkSpell)
    {
        string CurrentLine = "";
        int count = 0;
        
        try
        {
            ....
            if (lineNumber < count)
            {
                CurrentLine = lines.Skip(lineNumber).First();
                lineNumber++;
            }
            else 
            {
                chkSpell.NoMoreWords = true;
                ....
            } 
            ....
        }
        ....
     }
