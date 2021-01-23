    string XHTML = @"
    <table border='1'><tr>
    <td style='writing-mode:sideways-lr;text-align:center;width:40px;'>First</td>
    <td style='writing-mode:sideways-lr;text-align:center;width:40px;'>Second</td></tr>
    <tr><td style='text-align:center'>1</td>
    <td style='text-align:center'>2</td></tr></table>";
    using (var stream = new FileStream(OUTPUT_FILE, FileMode.Create))
    {
        using (var document = new Document())
        {
            var writer = PdfWriter.GetInstance(document, stream);
            document.Open();
            var tagProcessorFactory = Tags.GetHtmlTagProcessorFactory();
            tagProcessorFactory.AddProcessor(
                new TableDataProcessor(), 
                new string[] { HTML.Tag.TD }
            );
            var htmlPipelineContext = new HtmlPipelineContext(null);
            htmlPipelineContext.SetTagFactory(tagProcessorFactory);
            var pdfWriterPipeline = new PdfWriterPipeline(document, writer);
            var htmlPipeline = new HtmlPipeline(htmlPipelineContext, pdfWriterPipeline);
            var cssResolverPipeline = new CssResolverPipeline(
                XMLWorkerHelper.GetInstance().GetDefaultCssResolver(true), 
                htmlPipeline
            );
            var worker = new XMLWorker(cssResolverPipeline, true);
            var parser = new XMLParser(worker);
            using (var stringReader = new StringReader(XHTML))
            {
                parser.Parse(stringReader);
            }
        }
    }
