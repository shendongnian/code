            using (Document document = new Document(size))
            {
                var writer = PdfWriter.GetInstance(document, stream);
                document.Open();
                document.NewPage();
                document.Add(new Chunk(""));
                var tagProcessors = (DefaultTagProcessorFactory)Tags.GetHtmlTagProcessorFactory();
                tagProcessors.RemoveProcessor(HTML.Tag.IMG);
                tagProcessors.AddProcessor(HTML.Tag.IMG, new CustomImageTagProcessor());
                var charset = Encoding.UTF8;
                CssFilesImpl cssFiles = new CssFilesImpl();
                cssFiles.Add(XMLWorkerHelper.GetInstance().GetDefaultCSS());
                var cssResolver = new StyleAttrCSSResolver(cssFiles);
                cssResolver.AddCss(srcCssData, "utf-8", true);
                var hpc = new HtmlPipelineContext(new CssAppliersImpl(new XMLWorkerFontProvider()));
                hpc.SetAcceptUnknown(true).AutoBookmark(true).SetTagFactory(tagProcessors);
                var htmlPipeline = new HtmlPipeline(hpc, new PdfWriterPipeline(document, writer));
                var pipeline = new CssResolverPipeline(cssResolver, htmlPipeline);
                var worker = new XMLWorker(pipeline, true);
                var xmlParser = new XMLParser(true, worker, charset);
                xmlParser.Parse(new StringReader(srcFileData));
                document.Close();
            }
