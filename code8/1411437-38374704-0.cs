    var range = doc.Content;
    if (range.Find.Execute(txt))
    {
        range.Expand(WdUnits.wdLine); // or change to .wdSentence or .wdParagraph
        range.Delete();
    }
