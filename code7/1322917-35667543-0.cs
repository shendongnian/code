    private void ChangeTextColor(string text, Color color)
    {
        string textStr;
    
        myRichEdit.Document.GetText(TextGetOptions.None, out textStr);
    
        var myRichEditLength = textStr.Length;
    
        myRichEdit.Document.Selection.SetRange(0, myRichEditLength);
        int i = 1;
        while (i > 0)
        {
            i = myRichEdit.Document.Selection.FindText(text, myRichEditLength, FindOptions.Case);
    
            ITextSelection selectedText = myRichEdit.Document.Selection;
            if (selectedText != null)
            {
                selectedText.CharacterFormat.BackgroundColor = color;
            }
        }
    }
