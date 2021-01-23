    static void Main()
        {
            string ASCIIString = @"
                ---       ---      |    |  |     -----   
                 /         _|      |    |__|     |___    
                 \        |        |       |         |   
                --        ---      |       |     ____|  ";
            string[] lines =
                ASCIIString.Split(new[] {"\n","\r\n"}, StringSplitOptions.RemoveEmptyEntries);
            lines = lines.ReplaceSpacesWithSeparator("$");
            ASCIINumbersParser parser = new ASCIINumbersParser(lines, "$");
            // Try to find all numbers contained in the ASCII string
            foreach (string[] candidate in parser.CandidatesList)
            {
                for (int i = 1; i < 10; ++i)
                {
                    string[] num = ASCIINumberHelper.GetASCIIRepresentationForNumber(i);
                    if (ASCIINumberHelper.ASCIIRepresentationMatch(num, candidate))
                        Console.WriteLine("Number {0} was found in the string.", i);
                }
            }
        }
        // Expected output:
        // Number 3 was found in the string.
        // Number 2 was found in the string.
        // Number 1 was found in the string.
        // Number 4 was found in the string.
        // Number 5 was found in the string.
