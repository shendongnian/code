    public void Justify(System.Windows.Forms.Label label)
    {
        string text = label.Text;
        string[] lines = text.Split(new[]{"\r\n"}, StringSplitOptions.None).Select(l => l.Trim()).ToArray();
        List<string> result = new List<string>();
        foreach (string line in lines)
        {
            result.Add(StretchToWidth(line, label));
        }
        label.Text = string.Join("\r\n", result);
    }
    private string StretchToWidth(string text, Label label)
    {
        if (text.Length < 2)
            return text;
        // A hair space is the smallest possible non-visible character we can insert
        const char hairspace = '\u200A';
        // If we measure just the width of the space we might get too much because of added paddings so we have to do it a bit differently
        double basewidth = TextRenderer.MeasureText(text, label.Font).Width;
        double doublewidth = TextRenderer.MeasureText(text + text, label.Font).Width;
        double doublewidthplusspace = TextRenderer.MeasureText(text + hairspace + text, label.Font).Width;
        double spacewidth = doublewidthplusspace - doublewidth;
        //The space we have to fill up with spaces is whatever is left
        double leftoverspace = label.Width - basewidth;
        //Calculate the amount of spaces we need to insert
        int approximateInserts = Math.Max(0, (int)Math.Floor(leftoverspace / spacewidth));
        //Insert spaces
        return InsertFillerChar(hairspace, text, approximateInserts);
    }
    private static string InsertFillerChar(char filler, string text, int inserts)
    {
        string result = "";
        int inserted = 0;
        for (int i = 0; i < text.Length; i++)
        {
            //Add one character of the original text
            result += text[i];
            //Only add spaces between characters, not at the end
            if (i >= text.Length - 1) continue;
            //Determine how many characters should have been inserted so far
            int shouldbeinserted = (int)(inserts * (i+1) / (text.Length - 1.0));
            int insertnow = shouldbeinserted - inserted;
            for (int j = 0; j < insertnow; j++)
                result += filler;
            inserted += insertnow;
        }
        return result;
    }
