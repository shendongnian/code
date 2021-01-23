    public class OutputFormatter
    {
        public const int OutputMaxLength = 16;
        public static string[] Format(string output)
        {
            int offset = 0;
            List<string> outputParsed = new List<string>();
            while (offset < output.Length)
            {
                outputParsed.Add(output.Substring(offset, Math.Min(OutputMaxLength, output.Length - offset)));
                offset += OutputMaxLength;
            }
            return outputParsed.ToArray();
        }
    }
    private static string[][] strings = { 
            new string[] {"CompareLastTwo","Shows difference between friends lists of last two Facebook data files in repository"},
            new string[] {"AddFriendList <DataFolderPath>", "blah blah blah"}
        };
    public static void Main(string[] args)
    {
        foreach (string[] pair in strings)
        {
            string[] value0 = OutputFormatter.Format(pair[0]);
            string[] value1 = OutputFormatter.Format(pair[1]);
            int maxRows = Math.Max(value0.Length, value1.Length);
            string template = "{0," + OutputFormatter.OutputMaxLength + "} | {1," + OutputFormatter.OutputMaxLength + "}";
            for (int row = 0; row < maxRows; row++)
            {
                Console.Write
                (
                    template,
                    value0.Length > row ? value0[row] : null,
                    value1.Length > row ? value1[row] : null
                );
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', OutputFormatter.OutputMaxLength * 2));
        }
    }
