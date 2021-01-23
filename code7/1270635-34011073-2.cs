    while ((line = myFile.ReadLine()) != null)
    {
        counter++;
        int index = line.IndexOf(userText, StringComparison.CurrentCultureIgnoreCase);
        if (index != -1)
        {
            //Since we want the word that this entry is, we need to find the space in front of this word
            string sWordFound = string.Empty;
            string subLine = line.Substring(0, index);
            int iWordStart = subLine.LastIndexOf(' ');
            if (iWordStart == -1)
            {
                //If there is no space in front of this word, then this entry begins at the start of the line
                iWordStart = 0;
            }
    
            //We also need to find the space after this word
            subLine = line.Substring(index);
            int iTempIndex = subLine.LastIndexOf(' ');
            int iWordLength = -1;
            if (iTempIndex == -1)
            {    //If there is no space after this word, then this entry goes to the end of the line.
                sWordFound = line.Substring(iWordStart);
            }
            else
            {
                iWordLength = iTempIndex + index - iWordStart;
                sWordFound = line.Substring(iWordStart, iWordLength);
            }
    
            Console.WriteLine("Found {1} on line number: {0}", counter, sWordFound);
            found++;
        }
    }
