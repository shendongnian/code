    int imagescount = 0;
            private void SaveImageFromWebBrowser()
            {
                IHTMLDocument2 doc = (IHTMLDocument2)webBrowser1.Document.DomDocument;
                IHTMLControlRange imgRange = (IHTMLControlRange)((HTMLBody)doc.body).createControlRange();
    
                foreach (IHTMLImgElement img in doc.images)
                {
                    imgRange.add((IHTMLControlElement)img);
    
                    imgRange.execCommand("Copy", false, null);
    
                    using (Bitmap bmp = (Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap))
                    {
                        bmp.Save(@"e:\webbrowserimages\Image" + imagescount.ToString("D6") + ".bmp",
                                 System.Drawing.Imaging.ImageFormat.Bmp);
                    }
                    imagescount++;
                }
            }
