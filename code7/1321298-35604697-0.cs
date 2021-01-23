    private void fctbEditor_MouseHover(object sender, EventArgs e)
    {
        int charIndex = fctbEditor.PointToPosition(fctbEditor.PointToClient(Cursor.Position));
        if (charIndex != fctbEditor.Text.Length && fctbEditor.Text.Length > 0 && fctbEditor.Text[charIndex] != ' ')
        {
            String hoverWord = GetWord(charIndex);
    
            // Do with the word as you please
            Console.Out.WriteLine(" - Index: " + charIndex + " Char[" + fctbEditor.Text[charIndex].ToString() + "] Word[" + hoverWord + "]");
        }
    }
    
    private String GetWord(int charPos)
    {
        int revPos = charPos;
        char curChar = fctbEditor.Text[revPos];
        while (curChar != ' ' && curChar != '\n' && revPos > 0)
        {
            revPos -= 1;
            curChar = fctbEditor.Text[revPos];
        }
    
        int forPos = charPos;
        curChar = fctbEditor.Text[forPos];
        while(curChar != ' ' && curChar != '\n' && forPos < fctbEditor.Text.Length)
        {
            forPos += 1;
            curChar = fctbEditor.Text[forPos];
        }
    
        return fctbEditor.Text.Substring(revPos + 1, forPos - revPos - 1);
    }
