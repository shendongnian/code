    class XyzmoSignatureDataExtractor
    {
        private PdfReader reader;
        public XyzmoSignatureDataExtractor(PdfReader reader)
        {
            this.reader = reader;
        }
        public PdfImageObject extractImage(String signatureName) 
        {
            MyImageRenderListener listener = new MyImageRenderListener();
            PdfDictionary sigFieldDic = reader.AcroFields.GetFieldItem(signatureName).GetMerged(0);
            PdfDictionary appearancesDic = sigFieldDic.GetAsDict(PdfName.AP);
            PdfStream normalAppearance = appearancesDic.GetAsStream(PdfName.N);
            PdfDictionary resourcesDic = normalAppearance.GetAsDict(PdfName.RESOURCES);
            PdfContentStreamProcessor processor = new PdfContentStreamProcessor(listener);
            processor.ProcessContent(ContentByteUtils.GetContentBytesFromContentObject(normalAppearance), resourcesDic);        
            return listener.image;
        }
        class MyImageRenderListener : IRenderListener
        {
            public void BeginTextBlock() { }
            public void EndTextBlock() { }
            public void RenderImage(ImageRenderInfo renderInfo)
            {
                try
                {
                    image = renderInfo.GetImage();
                }
                catch (Exception e)
                {
                    throw new Exception("Failure retrieving image", e);
                }
            }
            public void RenderText(TextRenderInfo renderInfo) { }
            public PdfImageObject image = null;
        }
    }
