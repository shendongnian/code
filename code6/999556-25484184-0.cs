    Word.Application word = new Word.Application();
    Word.Document doc = word.Documents.Open(fileName, ReadOnly : readOnly, Visible: isVisible);
    private void ButtonClickHandler(object sender, EventArgs e)
    {
        doc.PrintOut();
    }
