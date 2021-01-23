    label1.Text = JustifyParagraph(label1.Text, label1.Font, label1.ClientSize.Width);
    public string JustifyParagraph(string text, Font font, int ControlWidth)
    {
        string result = string.Empty;
        List<string> ParagraphsList = new List<string>();
	    ParagraphsList.AddRange(text.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList());
        foreach (string Paragraph in ParagraphsList) {
            string line = string.Empty;
            int ParagraphWidth = TextRenderer.MeasureText(Paragraph, font).Width;
            if (ParagraphWidth > ControlWidth) {
                //Get all paragraph words, add a normal space and calculate when their sum exceeds the constraints
                string[] Words = Paragraph.Split(' ');
                line = Words[0] + (char)32;
                for (int x = 1; x < Words.Length; x++) {
                    string tmpLine = line + (Words[x] + (char)32);
                    if (TextRenderer.MeasureText(tmpLine, font).Width > ControlWidth)
                    {
                        //Max lenght reached. Justify the line and step back
                        result += Justify(line.TrimEnd(), font, ControlWidth) + "\r\n";
                        line = string.Empty;
                        --x;
                    } else {
                        //Some capacity still left
                        line += (Words[x] + (char)32);
                    }
                }
                //Adds the remainder if any
                if (line.Length > 0)
                result += line + "\r\n";
            }
            else {
                result += Paragraph + "\r\n";
            }
        }
        return result.TrimEnd(new[]{ '\r', '\n' });
    }
