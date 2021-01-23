    sparePicture = ByteArrayToImage(fetch); //<-- This is what you're missing
    Clipboard.SetDataObject(sparePicture);
    var oPara2 = oDoc.Content.Paragraphs.Add(ref oMissing);
    oPara2.Range.Paste();
    oPara2.Range.InsertParagraphAfter();
...
    public Image ByteArrayToImage(byte[] byteArrayIn)
    {
        MemoryStream ms = new MemoryStream(byteArrayIn);
        Image returnImage = Image.FromStream(ms);
        return returnImage;
    }
