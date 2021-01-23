    public void MyPDFExport()
    {
        string url = @"d:\Foo.html";
        string html = RenderRazorViewToString("File", "myName");
        System.IO.File.WriteAllBytes(url, System.Text.Encoding.ASCII.GetBytes(html));
    
        var document = new HtmlToPdfDocument
        {
            GlobalSettings = new GlobalSettings(),
            Objects = 
            {
                new ObjectSettings 
                { 
                    HtmlText = "<p>Some Html</p>",
                    FooterSettings = new FooterSettings { HtmlUrl = url }
                }
            }
        };
        IConverter converter =
            new ThreadSafeConverter(
                new RemotingToolset<PdfToolset>(
                    new Win32EmbeddedDeployment(
                        new TempFolderDeployment())));
        byte[] result = converter.Convert(document);
    }
