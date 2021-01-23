    private List<string> DrawOutline(List<string> inputLines)
    {
        List<string> output = new List<string>();
        int door = r.Next(0, inputLines.Last().Length);
        for (int li = 0; li < inputLines.Count; li++)
        {
            char[] curLine = inputLines[li].ToCharArray();
            string outputLine1 = string.Empty;
            string outputLine2 = string.Empty;
            for (int i = 0; i < curLine.Length -1; i++)
            {
                Console.WriteLine(curLine[i]);
                if (curLine[i] == '*')
                {
                    outputLine1 += "+---";
                    outputLine2 += "|   ";
                }
                else
                {
                    outputLine1 += "    ";
                    outputLine2 += "    ";
                }
                if (curLine[i] == '*' && (curLine.Length == i+1 || curLine[i + 1] != '*'))
                {
                    outputLine1 += "+";
                    outputLine2 += "|";
                }
                
            }
            output.Add(outputLine1);
            output.Add(outputLine2); 
        }
        return output;
    }
