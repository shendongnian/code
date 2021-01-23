        public static string[] splitCSV(string CSVLineWithQuotedTextWithCommas)
        {
            Regex regExToSeperate = new Regex("(?:^|,)(\"(?:[^\"]+|\"\")*\"|[^,]*)", RegexOptions.Compiled);
            List<string> result = new List<string>();
            string curr = null;
            foreach (Match match in regExToSeperate.Matches(CSVLineWithQuotedTextWithCommas))
            {
                curr = match.Value;
                if (0 == curr.Length)
                {
                    result.Add("");
                }
                result.Add(curr.TrimStart(','));
            }
            return result.ToArray<string>();
        }
