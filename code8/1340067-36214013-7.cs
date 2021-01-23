    public void ProcessPdf(string xHtml, string css)
    {
        using (var stream = new FileStream(OUTPUT_FILE, FileMode.Create))
        {
            using (var document = new Document())
            {
                var writer = PdfWriter.GetInstance(document, stream);
                document.Open();
                // instantiate custom tag processor and add to `HtmlPipelineContext`.
                var tagProcessorFactory = Tags.GetHtmlTagProcessorFactory();
                tagProcessorFactory.AddProcessor(
                    new TableDataProcessor(), 
                    new string[] { HTML.Tag.TD }
                );
                var htmlPipelineContext = new HtmlPipelineContext(null);
                htmlPipelineContext.SetTagFactory(tagProcessorFactory);
                var pdfWriterPipeline = new PdfWriterPipeline(document, writer);
                var htmlPipeline = new HtmlPipeline(htmlPipelineContext, pdfWriterPipeline);
                // get an ICssResolver and add the custom CSS
                var cssResolver = XMLWorkerHelper.GetInstance().GetDefaultCssResolver(true);
                cssResolver.AddCss(css, "utf-8", true);
                var cssResolverPipeline = new CssResolverPipeline(
                    cssResolver, htmlPipeline
                );
                var worker = new XMLWorker(cssResolverPipeline, true);
                var parser = new XMLParser(worker);
                using (var stringReader = new StringReader(xHtml))
                {
                    parser.Parse(stringReader);
                }
            }
        }
    }
