    public class DocToHtml
    {
        private TikaConfig config = TikaConfig.getDefaultConfig();
        public void Convert()
        {
            byte[] file = Files.toByteArray(new File(@"filename.doc"));
            AutoDetectParser tikaParser = new AutoDetectParser();
            ByteArrayOutputStream output = new ByteArrayOutputStream();
            SAXTransformerFactory factory = (SAXTransformerFactory)TransformerFactory.newInstance();
            var inputStream = new ByteArrayInputStream(file);
            //           ToHTMLContentHandler handler = new ToHTMLContentHandler();
            var metaData = new Metadata();
            EncodingDetector encodingDetector = new UniversalEncodingDetector();
            var encode = encodingDetector.detect(inputStream, metaData) ?? new UTF_32();
            TransformerHandler handler = factory.newTransformerHandler();
            handler.getTransformer().setOutputProperty(OutputKeys.METHOD, "html");
            handler.getTransformer().setOutputProperty(OutputKeys.INDENT, "yes");
            handler.getTransformer().setOutputProperty(OutputKeys.ENCODING, encode.toString());
            handler.setResult(new StreamResult(output));
            ContentHandler imageRewriting = new ImageRewritingContentHandler(handler); 
            //  ExpandedTitleContentHandler handler1 = new ExpandedTitleContentHandler(handler);
            ParseContext context = new ParseContext();
            context.set(typeof(EmbeddedDocumentExtractor), new FileEmbeddedDocumentEtractor());
            tikaParser.parse(inputStream, imageRewriting, new Metadata(), context);
       
            byte[] array =  output.toByteArray();
           System.IO.File.WriteAllBytes(@"C:\toHtml\text.html", array);
        }
        private class ImageRewritingContentHandler : ContentHandlerDecorator
        {
            public ImageRewritingContentHandler(ContentHandler handler) : base(handler)
            {
            }
            public override void startElement(string uri, string localName, string name, Attributes origAttrs)
            {
                if ("img".Equals(localName))
                {
                    AttributesImpl attrs;
                    if (origAttrs is AttributesImpl)
                        attrs = (AttributesImpl)origAttrs;
                    else
                        attrs = new AttributesImpl(origAttrs);
                    for (int i = 0; i < attrs.getLength(); i++)
                    {
                        if ("src".Equals(attrs.getLocalName(i)))
                        {
                            String src = attrs.getValue(i);
                            if (src.StartsWith("embedded:"))
                            {
                                var newSrc = src.Replace("embedded:", @"images\");
                                attrs.setValue(i, newSrc);
                            }
                        }
                    }
                    attrs.addAttribute(null, "width", "width","width", "100px");
                    base.startElement(uri, localName, name, attrs);
                }
                else
                    base.startElement(uri, localName, name, origAttrs);
            }
        }
        private class FileEmbeddedDocumentEtractor : EmbeddedDocumentExtractor
        {
            private int count = 0;
            public bool shouldParseEmbedded(Metadata m)
            {
                return true;
            }
            public void parseEmbedded(InputStream inputStream, ContentHandler contentHandler, Metadata metadata, bool outputHtml)
            {
                Detector detector = new DefaultDetector();
                string name = metadata.get("resourceName");
                MediaType contentType = detector.detect(inputStream, metadata);
                if (contentType.getType() != "image") return;
                var embeddedFile = name;
                File outputFile = new File(@"C:\toHtml\images", embeddedFile);
                try
                {
                    using (FileOutputStream os = new FileOutputStream(outputFile))
                    {
                        var tin = inputStream as TikaInputStream;
                        if (tin != null)
                        {
                            if (tin.getOpenContainer() != null && tin.getOpenContainer() is DirectoryEntry)
                            {
                                POIFSFileSystem fs = new POIFSFileSystem();
                                fs.writeFilesystem(os);
                            }
                            else
                            {
                                IOUtils.copy(inputStream, os);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
