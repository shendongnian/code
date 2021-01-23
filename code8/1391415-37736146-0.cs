     public string FormatPickSlipNoteLines(string input)
            {
                if (string.IsNullOrEmpty(input))
                    return "";
                else if (input.Length < PAGE_COLUMN_SIZE)
                    return ALIGN_PAGE_CENTER + input + ALIGN_PAGE_LEFT;
                else
                {
                    string[] str = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);               
                    StringBuilder sbFormatter = new StringBuilder();
                    for (int i = 0; i < str.Length; i++)
                    {
                        sbFormatter.Append("        " + str[i] + NEW_LINE);                 
                    }
                    return sbFormatter.Append(NEW_LINE + ALIGN_PAGE_LEFT).ToString();
                }
            }
