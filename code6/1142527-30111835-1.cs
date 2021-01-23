    private static int FindEndOfMethod(string filename, string methodToFind)
    {
        int countStartBracket = 0;
        int countEndBracket = 0;
        string line = "";
        int lineNumber = -1;
        bool foundEnd = false;
        bool foundMethod = false;
        System.Action countBrackets = () =>
        {
            if (line.Contains("{"))
                countStartBracket++;
            if (line.Contains("}"))
                countEndBracket++;
            //If we found the method and the start and end bracke- count is the same we found the end (and they are not zero)
            if (foundMethod && countStartBracket == countEndBracket && countStartBracket != 0 && countEndBracket != 0)
                foundEnd = true;
        };
        //Pass the file path and file name to the StreamReader constructor
        using (StreamReader sr = new StreamReader(filename))
        {
            //Continue to read until you reach end of file
            while (line != null)
            {
                lineNumber++;
                //Read next line, if it's null, we reached end of file and didn't find the place
                if ((line = sr.ReadLine()) == null)
                    return -1;
                //If we haven't found the method yet, we check each line to see if it's on this line
                if (!foundMethod)
                    if (line.Contains(methodToFind))
                        foundMethod = true;
                //If it was or has been found we count brackets to determine the closing one
                if (foundMethod)
                    countBrackets();
                if (foundEnd)
                {
                    Debug.Log(lineNumber);
                    return lineNumber;
                }
            }
            return -1;
        }
    }
