    class Program
    {
        static void Main(string[] args)
        {
            string[][] sampleInput = {
                new string[] { "Column 1 Head", "Column 2 Header" },
                new string[] { "klm", "nopqrstuvwxyz" },
                new string[] { "klm dksfj sldkf sdlk", "nalsdk als dkasopqrstuvwxyz" }
            };
    
            PrintJaggedArrayWithWrappedLines(sampleInput, 15, 12);
    
            Console.ReadLine();
        }
    
        public static void PrintJaggedArrayWithWrappedLines(string[][] jaggedArray, int leftColumnMaxWidth, int rightColumnMaxWidth)
        {
            for (int j = 0; j < jaggedArray.Length; j++)
            {
                string[] aRow = jaggedArray[j];
                int leftColumnNumLines = (int)Math.Ceiling((double)aRow[0].Length / (double)leftColumnMaxWidth);
                int rightColumnNumLines = (int)Math.Ceiling((double)aRow[1].Length / (double)rightColumnMaxWidth);
                int numberLines = Math.Max(leftColumnNumLines, rightColumnNumLines);
    
                string leftColumn = aRow[0].PadRight(numberLines * leftColumnMaxWidth, ' ');
                string rightColumn = aRow[1].PadRight(numberLines * rightColumnMaxWidth, ' ');
    
                for (int i = 0; i < numberLines; i++)
                {
                    Console.WriteLine(" {0} | {1} ", leftColumn.Substring(i * leftColumnMaxWidth, leftColumnMaxWidth), rightColumn.Substring(i * rightColumnMaxWidth, rightColumnMaxWidth));
                }
                if (j == 0)
                {
                    Console.WriteLine(new String('-', leftColumnMaxWidth + rightColumnMaxWidth + 4));
                }
            }
        }
    }
