           static void Main(string[] args)
            {
                string input = "00H1,00H1,00H2,00H1,00H1,00H2,00H2,00H2,00H3,00H3,00H2,00H3";
                List<string> array = input.Split(new char[] { ',' }).ToList();
                array = array.Select(x => new
                {
                    suffix = GetSuffix(x),
                    item = x
                }).OrderBy(x => x.suffix).Select(x => x.item).ToList();
                string output = string.Join(",",array);
            }
            static int GetSuffix(string input)
            {
                string pattern = "H(?'suffix'\\d*)";
                Match match = Regex.Match(input, pattern);
                return int.Parse(match.Groups["suffix"].Value);
            }​
