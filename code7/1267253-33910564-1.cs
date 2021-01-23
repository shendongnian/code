    public string ShiftText(string input, int shift)
    {
        // This makes sure the shift is *always* in the range 0-25.
        shift = ((shift % 26) + 26) % 26;
        StringBuilder output = new StringBuilder();
        foreach (char c in input)
        {
            if (c >= 'a' && c <= 'z')
            {
                // We'll sort this later
            }
            else if (c >= 'A' && c <= 'Z')
            {
                // We'll sort this later
            }
            else
            {
                output.Append(c);
            }
        }
        return output.ToString();
    }
