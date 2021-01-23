    public static int GetLineCount(string input)
    {
        int lineCount = 0;
        for (int i = 0; i < input.Length; i++)
        {
            switch (input[i])
            {
                case '\r':
                    {
                        if (i + 1 < input.Length)
                        {
                            i++;
                            if (input[i] == '\r')
                            {
                                lineCount += 2;
                            }
                            else
                            {
                                lineCount++;
                            }
                        }
                        else
                        {
                            lineCount++;
                        }
                    }
                    break;
                case '\n':
                    lineCount++;
                    break;
                default:
                    break;
            }
        }
