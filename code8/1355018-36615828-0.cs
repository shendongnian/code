    private static string f_get_acronym(string s_input)
    {
            if (string.IsNullOrWhiteSpace(s_input))
                return string.Empty;
            string accr = string.Empty;
            accr += s_input[0];
            while (s_input.Length > 0)
            {
                int index = s_input.IndexOf(' ');
                if (index > 0)
                {
                    s_input = s_input.Substring(index + 1);
                    if (s_input.Length == 0)
                        break;
                    accr += s_input[0];
                }
                else
                {
                    break;
                }
            }
            return accr.ToUpper();
    }
