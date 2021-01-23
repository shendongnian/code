    class Program
    {
        private const string _kinvalidFormatException = "Invalid format for edit specification";
        private static readonly Regex
            regex1 = new Regex(@"(?<word>[^,]+),(?<edit>(?:\d+)(?:-(?:\d+))?:(?:[^;]+);?)+", RegexOptions.Compiled),
            regex2 = new Regex(@"(?<start>\d+)(?:-(?<end>\d+))?:(?<furigana>[^;]+);?", RegexOptions.Compiled);
        static void Main(string[] args)
        {
            string myString = "子で子にならぬ時鳥,0:こ;2:こ;7-8:ほととぎす";
            string result = EditString(myString);
        }
        private static string EditString(string myString)
        {
            Match editsMatch = regex1.Match(myString);
            if (!editsMatch.Success)
            {
                throw new ArgumentException(_kinvalidFormatException);
            }
            int ichCur = 0;
            string input = editsMatch.Groups["word"].Value;
            StringBuilder text = new StringBuilder();
            foreach (Capture capture in editsMatch.Groups["edit"].Captures)
            {
                Match oneEditMatch = regex2.Match(capture.Value);
                if (!oneEditMatch.Success)
                {
                    throw new ArgumentException(_kinvalidFormatException);
                }
                int start, end;
                if (!int.TryParse(oneEditMatch.Groups["start"].Value, out start))
                {
                    throw new ArgumentException(_kinvalidFormatException);
                }
                Group endGroup = oneEditMatch.Groups["end"];
                if (endGroup.Success)
                {
                    if (!int.TryParse(endGroup.Value, out end))
                    {
                        throw new ArgumentException(_kinvalidFormatException);
                    }
                }
                else
                {
                    end = start;
                }
                text.Append(input.Substring(ichCur, start - ichCur));
                if (text.Length > 0)
                {
                    text.Append(' ');
                }
                ichCur = end + 1;
                text.Append(input.Substring(start, ichCur - start));
                text.Append(string.Format("[{0}]", oneEditMatch.Groups["furigana"]));
            }
            if (ichCur < input.Length)
            {
                text.Append(input.Substring(ichCur));
            }
            return text.ToString();
        }
    }
