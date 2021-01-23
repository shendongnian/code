        public static int FindEndOfMethodLineNumber(string filename, string methodToFind)
        {
           //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader(filename);
            //Read the first line of text
            line = sr.ReadLine();
            int lineNumber = 0;
            int countStartBracket = 0;
            int countEndBracket = 0;
            bool foundMethod = false;
            bool foundEnd = false;
            //Continue to read until you reach end of file
            while (line != null)
            {
                //Read the next line
                line = sr.ReadLine();
                lineNumber++;
                if (!foundMethod)
                {
                    if (line.Contains(methodToFind))
                    {
                        foundMethod = true;
                        
                    if (line.Contains("{"))
                        countStartBracket++;
                    if (line.Contains("}"))
                        countEndBracket++;
                    if (countStartBracket == countEndBracket && countStartBracket != 0 && countEndBracket != 0)
                        foundEnd = true;
                    }
                }
                else
                {
                    if (line.Contains("{"))
                        countStartBracket++;
                    if (line.Contains("}"))
                        countEndBracket++;
                    if (countStartBracket == countEndBracket && countStartBracket != 0 && countEndBracket != 0)
                        foundEnd = true;
                }
                if (foundEnd)
                {
                    return lineNumber;
                }
            }
            //close the file
            sr.Close();
            return -1;
        }
