    public class ASCIINumbersParser
    {
        // Will store a list of all the possible numbers
        // found in the text.
        public List<string[]> CandidatesList { get; }
        public ASCIINumbersParser(string[] text, string separator)
        {
            CandidatesList = new List<string[]>();
            string[][] candidates = new string[text.Length][];
            for (int n = 0; n < text.Length; ++n)
            {
                // Split each line in the text, using the separator char/string.
                candidates[n] =
                    text[n].Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            }
            // Put the strings in such a way that each CandidateList item
            // contains only one possible number found in the text.
            for (int i = 0; i < candidates[0].Length; ++i)
                CandidatesList.Add(candidates.Select(c => c[i]).ToArray());
        }
    }
