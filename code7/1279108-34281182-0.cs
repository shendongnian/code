    public void SetRTFText(string text)
    {
        MemoryStream stream = new MemoryStream(ASCIIEncoding.Default.GetBytes(text));
        this.mainRTB.Selection.Load(stream, DataFormats.Rtf);
    }
