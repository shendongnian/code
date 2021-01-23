    internal string Create(PdfDocumentDefinition documentDefinition)
    {
        string pathName = @WebConfigurationManager.AppSettings["StagingPath"] + documentDefinition.DocumentName + ".pdf";
           
        MemoryStream input = new MemoryStream(Encoding.UTF8.GetBytes(documentDefinition.Source));
            
        Document document = new Document(PageSize.A4, 30, 30, 30, 30);
        MemoryStream output = new MemoryStream();
        using (output)
        { 
            PdfWriter writer = PdfWriter.GetInstance(document, output);
            document.Open();
            CssResolverPipeline pipeline = SetCssResolver(documentDefinition.CssFiles, document, writer);
            XMLWorker worker = new XMLWorker(pipeline, true);
            XMLParser parser = new XMLParser(worker);
            parser.Parse(input);
            output.Position = 0;
            Byte[] firstBytes = output.ToArray();
            document.Close();
            Byte[] lastBytes = output.ToArray();
            Byte[] allBytes = new Byte[firstBytes.Length + lastBytes.Length];
            firstBytes.CopyTo(allBytes, 0);
            lastBytes.CopyTo(allBytes, firstBytes.Length);
            File.WriteAllBytes(pathName, allBytes);
        }
        return pathName;
    }
    private CssResolverPipeline SetCssResolver(List<String> cssFiles, Document document, PdfWriter writer)
    {            
        var htmlContext = new HtmlPipelineContext(null);
           htmlContext.SetTagFactory(iTextSharp.tool.xml.html.Tags.GetHtmlTagProcessorFactory());
        ICSSResolver cssResolver = XMLWorkerHelper.GetInstance().GetDefaultCssResolver(false);
        if (cssFiles != null)
        {
            foreach (String cssFile in cssFiles)
            {
                cssResolver.AddCssFile(cssFile, true);
            }
        }
        return new CssResolverPipeline(cssResolver, new HtmlPipeline(htmlContext, new PdfWriterPipeline(document, writer)));            
    }
