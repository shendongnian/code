    private List<string> ExtractFromString(string s, string startTag, string endTag)
        {
            var names = new List<string>();
            int startPos = 0;
            int endPos = 0;
            while (true)
            {
                startPos = richTextBox1.Text.IndexOf(textBox2.Text, endpos) + textBox2.Text.Length;
                if (startPos == -1)
                {
                    break;
                }
                int endPos = richTextBox1.Text.IndexOf(textBox3.Text, startPos);
                string extractedText = richTextBox1.Text.Substring(startPos, endPos - startPos).Trim();
            }
            return names;
        }
