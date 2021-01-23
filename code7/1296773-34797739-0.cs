    private void FormatCode(List<string> codeList)
        {
            for (int i = 0; i < codeList.Count; i++)
            {
                codeList[i] = FormatCode(codeList[i]);
            }
        }
        private string FormatCode(string code)
        {
            string formatted = String.Empty;
            MatchCollection matches = new Regex("\".*?\"").Matches(code);
            for (int i = 0; i < matches.Count; i++)
            {
                Match match = matches[i];
                string toFormat = i == 0 ? code.Substring(0, match.Index) : code.Substring(matches[i - 1].Index + matches[i - 1].Length, code.Length - match.Index);
                toFormat = String.Join(" ", toFormat.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
                formatted += toFormat + matches[i].Value;
                if(i == matches.Count - 1)
                    formatted += String.Join(" ", code.Substring(match.Index + match.Length).Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
            }
            return formatted;
        }
