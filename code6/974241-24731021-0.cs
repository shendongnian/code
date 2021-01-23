    void richEditControl1_KeyDown(object sender, KeyEventArgs e)
    {
        DocumentPosition pos = richEditControl1.Document.CaretPosition;
        Paragraph par = richEditControl1.Document.GetParagraph(pos);
        DocumentPosition newPos = richEditControl1.Document.CreatePosition(par.Range.End.ToInt());
        DocumentPosition start = richEditControl1.Document.Selection.Start;
        DocumentPosition end = richEditControl1.Document.Selection.End;
        int getStartpar = richEditControl1.Document.GetParagraph(start).Index;
        getSelectionStart = getStartpar;
        int getEndpar = richEditControl1.Document.GetParagraph(end).Index;
        getSelectionEnd = getEndpar;
        if (e.Shift)
        {
            richEditControl1.Document.CaretPosition = richEditControl1.Document.CreatePosition(start.ToInt());
            DocumentPosition carPos = richEditControl1.Document.CaretPosition;
            int getParOfcarPos = richEditControl1.Document.GetParagraph(carPos).Index;
            for (int i = getParOfcarPos; i < getEndpar; i++)
            {
                NextParagraphCommand s = new NextParagraphCommand(this.richEditControl1);
                s.Execute();
                richEditControl1.Document.InsertText(richEditControl1.Document.CaretPosition, "#");
            }
        }
    }
