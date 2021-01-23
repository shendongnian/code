    private string GetUsableTextFromRange(Word.HeaderFooter headerFooter)
    {
        Word.Range range = headerFooter.Range;
        string textWithSlashRs = range.Text;
        string usableText = textWithSlashRs.Replace("\r", Environment.NewLine);
        return usableText;
    }
