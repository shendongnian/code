    var file = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "test.pdf");
    var fontFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "NotoSansHebrew-Regular.ttf");
    var htmlText = @"<div dir=""rtl"" style=""font-family: Noto Sans Hebrew;"">שלום עולם</div>";
    using (var FS = new System.IO.FileStream(file, FileMode.Create, FileAccess.Write, FileShare.None)) {
        using (var document = new Document()) {
            using (var writer = PdfWriter.GetInstance(document, FS)) {
                document.Open();
                var cssResolver = new StyleAttrCSSResolver();
                var fontProvider = new XMLWorkerFontProvider(XMLWorkerFontProvider.DONTLOOKFORFONTS);
                fontProvider.Register(fontFile);
                var cssAppliers = new CssAppliersImpl(fontProvider);
                var htmlContext = new HtmlPipelineContext(cssAppliers);
                htmlContext.SetTagFactory(Tags.GetHtmlTagProcessorFactory());
                var pdf = new PdfWriterPipeline(document, writer);
                var html = new HtmlPipeline(htmlContext, pdf);
                var css = new CssResolverPipeline(cssResolver, html);
                var worker = new XMLWorker(css, true);
                var p = new XMLParser(worker);
                using (var ms = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(htmlText))) {
                    using (var sr = new StreamReader(ms)) {
                        p.Parse(sr);
                    }
                }
                document.Close();
            }
        }
    }
