            private bool TestMethod()
    {
        const string textPattern = "X###";
        string text = textBox1.Text;
        bool match = true;
        if (text.Length == textPattern.Length)
        {
            char[] chrStr = text.ToCharArray();
            char[] chrPattern = textPattern.ToCharArray();
            int length = text.Length;
            for (int i = 0; i < length; i++)
            {
                if (chrPattern[i] != '#')
                {
                    if (chrPattern[i] != chrStr[i])
                    {
                        return false;
                    }
                }
            }
        }
        else
        {
            return false;
        }
        return match;
    }
