    [TestMethod]
    public void TestInsertFile()
    {
        Application word = new Microsoft.Office.Interop.Word.Application();
        word.Visible = true;
        Document doc = word.Documents.Open(@"c:\temp\testdoc1.docx");
        Range rng = word.ActiveDocument.Bookmarks.get_Item("testbookmark").Range;
        object count = 1;
        object back = -1;
        rng.Move(Unit: Word.WdUnits.wdCharacter, Count: ref back);
        rng.Paragraphs.Add();
        rng.Move(Unit: Word.WdUnits.wdParagraph, Count: ref count);
        object obj = rng as object;
        Word.ContentControl wcc = word.ActiveDocument.ContentControls.Add(WdContentControlType.wdContentControlRichText, ref obj);
        wcc.LockContentControl = true;
        wcc.SetPlaceholderText(null, null, " ");
        wcc.Tag = @"c:\temp\testdoc2.docx";
        wcc.Range.InsertFile(wcc.Tag);
    }
