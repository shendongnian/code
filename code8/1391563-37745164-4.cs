            private void RegexCla(string value, string pattern, string data)
        {
            if(Regex.IsMatch(value, pattern) == true)
            {
                int index = 0;
                for (int i = 0; i < foo.lineno; i++)
                {
                    int gelen = rtb1.Lines[i].Length;
                    index = index + gelen;
                }
                rtb1.Find(data, index, RichTextBoxFinds.WholeWord);
                rtb1.SelectionColor = Color.Green;
                rtb1.SelectedText = value;
            }
            else
            {
                int index = 0;
                for (int i = 0; i < foo.lineno; i++)
                {
                    int gelen = rtb1.Lines[i].Length;
                    index = index + gelen;
                }
                rtb1.Find(data, index, RichTextBoxFinds.WholeWord);
                rtb1.SelectionColor = Color.Red;
            }
        }
