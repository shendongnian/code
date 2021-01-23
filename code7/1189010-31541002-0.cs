    /**
     * Parses an HTML string and a string containing CSS into a list of Element objects.
     * The FontProvider will be obtained from iText's FontFactory object.
     * 
     * @param   html    a String containing an XHTML snippet
     * @param   css     a String containing CSS
     * @return  an ElementList instance
     */
    public static ElementList ParseToElementList(String html, String css) {
        // CSS
        ICSSResolver cssResolver = new StyleAttrCSSResolver();
        if (css != null) {
            ICssFile cssFile = XMLWorkerHelper.GetCSS(new MemoryStream(Encoding.Default.GetBytes(css)));
            cssResolver.AddCss(cssFile);
        }
        // HTML
        CssAppliers cssAppliers = new CssAppliersImpl(FontFactory.FontImp);
        HtmlPipelineContext htmlContext = new HtmlPipelineContext(cssAppliers);
        htmlContext.SetTagFactory(Tags.GetHtmlTagProcessorFactory());
        htmlContext.AutoBookmark(false);
        // Pipelines
        ElementList elements = new ElementList();
        ElementHandlerPipeline end = new ElementHandlerPipeline(elements, null);
        HtmlPipeline htmlPipeline = new HtmlPipeline(htmlContext, end);
        CssResolverPipeline cssPipeline = new CssResolverPipeline(cssResolver, htmlPipeline);
        // XML Worker
        XMLWorker worker = new XMLWorker(cssPipeline, true);
        XMLParser p = new XMLParser(worker);
        p.Parse(new MemoryStream(Encoding.Default.GetBytes(html)));
        return elements;
    }
