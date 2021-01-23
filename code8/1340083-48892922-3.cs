    public void addHtmlToPdf_Utf8(Document document, PdfWriter writer, String html) 
    {
        XMLWorkerHelper xml = XMLWorkerHelper.GetInstance();
        xml.ParseXHtml(writer, document, stringToStream(html), System.Text.Encoding.UTF8);
    }
    public Stream stringToStream(string txt) {
        var stream = new MemoryStream();
        var w = new StreamWriter(stream);
        w.Write(txt);
        w.Flush();
        stream.Position = 0;
        return stream;
    }
