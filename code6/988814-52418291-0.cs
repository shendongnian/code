    protected void CreatePDF(Stream stream)
            {
                using (var document = new Document(PageSize.A4, 40, 40, 40, 30))
                {
                    var writer = PdfWriter.GetInstance(document, stream);
                    writer.PageEvent = new ITextEvents();
                    document.Open();
    
                    // instantiate custom tag processor and add to `HtmlPipelineContext`.
                    var tagProcessorFactory = Tags.GetHtmlTagProcessorFactory();
                    tagProcessorFactory.AddProcessor(
                        new TableProcessor(),
                        new string[] { HTML.Tag.TABLE }
                    );
    
                    //Register Fonts.
                    XMLWorkerFontProvider fontProvider = new XMLWorkerFontProvider(XMLWorkerFontProvider.DONTLOOKFORFONTS);
                    fontProvider.Register(HttpContext.Current.Server.MapPath("~/Content/Fonts/GothamRounded-Medium.ttf"), "Gotham Rounded Medium");
                    CssAppliers cssAppliers = new CssAppliersImpl(fontProvider);
    
                    var htmlPipelineContext = new HtmlPipelineContext(cssAppliers);
                    htmlPipelineContext.SetTagFactory(tagProcessorFactory);
    
                    var pdfWriterPipeline = new PdfWriterPipeline(document, writer);
                    var htmlPipeline = new HtmlPipeline(htmlPipelineContext, pdfWriterPipeline);
    
                    // get an ICssResolver and add the custom CSS
                    var cssResolver = XMLWorkerHelper.GetInstance().GetDefaultCssResolver(true);
                    cssResolver.AddCss(CSSSource, "utf-8", true);
                    var cssResolverPipeline = new CssResolverPipeline(
                        cssResolver, htmlPipeline
                    );
    
                    var worker = new XMLWorker(cssResolverPipeline, true);
                    var parser = new XMLParser(worker);
                    using (var stringReader = new StringReader(HTMLSource))
                    {
                        parser.Parse(stringReader);
                        document.Close();
                        HttpContext.Current.Response.ContentType = "application /pdf";
                        if (base.View)
                            HttpContext.Current.Response.AddHeader("content-disposition", "inline;filename=\"" + OutputFileName + ".pdf\"");
                        else
                            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=\"" + OutputFileName + ".pdf\"");
                        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        HttpContext.Current.Response.WriteFile(OutputPath);
                        HttpContext.Current.Response.End();
                    }
                }
            }
