    string ConvertDashToCamelCase(string input)
    {
        StringBuilder sb = new StringBuilder();
        bool caseFlag = false;
        for (int i = 0; i < input.Length; ++i)
        {
            char c = input[i];
            if (c == '-')
            {
                caseFlag = true;
            }
            else if (caseFlag)
            {
                sb.Append(char.ToUpper(c));
                caseFlag = false;
            }
            else
            {
                sb.Append(char.ToLower(c));
            }
        }
        return sb.ToString();
    }
