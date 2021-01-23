        private void button3_Click(object sender, EventArgs e)
        {
            test.Text = "act";
            Encoding encoder = new Encoding();
            foreach (string encoding in encoder.EncodedStrings(test.Text))
            {
                output.AppendText(encoding + "\n");
            }
        }
        public class Encoding
        {
            public readonly Dictionary<char, string[]> codes = new Dictionary<char, string[]>();
            public Encoding()
            {
                codes.Add('A', new string[] {"a  ", "A  ", "a1 ", "A1 "});
                codes.Add('B', new string[] {"b  ", "B  ", "b1 ", "B1 "});
                codes.Add('C', new string[] {"c  ", "C  ", "c1 ", "C1 "});
                codes.Add('D', new string[] {"d  ", "D  ", "d1 ", "D1 "});
                codes.Add('T', new string[] {"t  ", "T  ", "t1 ", "T1 "});
            }
            public List<string> EncodedStrings(string input)
            {
                var results = new List<string>();
                if (string.IsNullOrWhiteSpace(input))
                {
                    results.Add(string.Empty);
                    return results;
                }
                // Find the set of replacements for the first character:
                char     firstChar    = input[0];
                string[] replacements = this.codes[firstChar.ToString().ToUpperInvariant()[0]];
                foreach (string replacement in replacements)
                {
                    string thisVersion       = replacement;
                    string remainder         = input.Length > 1 ? input.Substring(1) : string.Empty;
                    var    remainderVersions = new List<string>();
                    // Get the various versions of the remainder of the string:
                    remainderVersions.AddRange(EncodedStrings(remainder));
                    foreach (string remainderVersion in remainderVersions)
                    {
                        results.Add(string.Format("{0}{1}", thisVersion, remainderVersion));
                    }
                }
                return results;
            }
        }
