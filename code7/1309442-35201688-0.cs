    List<char> invalidChars = new List<char> {" ", ";"};
    string finalString = "";
    using (StreamReader sr = new StreamReader("TestFile.txt"))
            {
                //grab line
                String line = sr.ReadToEnd();
                //grab first 10 chars of the line
                string firstChars = line.substring(0,10);
                //check if contains 
                bool hasInvalidChars = false;
                foreach(char c in invalidChars)
                {
                    if(firstChars.toLowerInvariant().IndexOf(c) == 1)
                       hasInvalidChars = true;
                }
                if(!hasInvalidChars)
                    finalString += line + Environment.NewLine;
            }
     //now store results
     using (System.IO.StreamWriter file = 
            new System.IO.StreamWriter(@"results.txt"))
     {
        file.write(finalString);
     }
