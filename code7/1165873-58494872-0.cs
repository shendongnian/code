                // getting keywords/functions
                string keywords = @"\b(e)\b";
                MatchCollection keywordMatches = Regex.Matches(codeRichTextBox.Text, keywords);
                // saving the original caret position + forecolor
                int originalIndex = codeRichTextBox.SelectionStart;
                int originalLength = codeRichTextBox.SelectionLength;
                Color originalColor = Color.Black;
                bool originalFont = Font.Italic;//Change this to your font
                // MANDATORY - focuses a label before highlighting (avoids blinking)
                menuStrip1.Focus();
                bool boldfont = Font.Bold;
                // removes any previous highlighting (so modified words won't remain highlighted)
                codeRichTextBox.SelectionStart = 0;
                codeRichTextBox.SelectionLength = codeRichTextBox.Text.Length;
                codeRichTextBox.SelectionColor = originalColor;
                // scanning...
                foreach (Match m in keywordMatches)
                {
                    codeRichTextBox.SelectionStart = m.Index;
                    codeRichTextBox.SelectionLength = m.Length;
                    codeRichTextBox.SelectionColor = Color.Blue;
                    codeRichTextBox.SelectionFont = boldfont;
                }
                // restoring the original colors, for further writing
                codeRichTextBox.SelectionStart = originalIndex;
                codeRichTextBox.SelectionLength = originalLength;
                codeRichTextBox.SelectionColor = originalColor;
                codeRichTextBox.SelectionFont = originalFont;
                // giving back the focus
                codeRichTextBox.Focus();
