        Byte[] MakePDFFromImages()
        {
            // open a new document
            PrintAttributes printAttributes = new PrintAttributes.Builder().
                SetColorMode(Android.Print.PrintColorMode.Color).
                SetMediaSize(PrintAttributes.MediaSize.IsoA4).
                SetResolution(new PrintAttributes.Resolution("zooey", "test", 450, 700)).
                SetMinMargins(PrintAttributes.Margins.NoMargins).
                Build();
            PrintedPdfDocument document = new PrintedPdfDocument(Activity.BaseContext, printAttributes);
            // start a page
            Android.Graphics.Pdf.PdfDocument.Page page = document.StartPage(0);
            ImageView imageView = new ImageView(Activity.BaseContext);
            imageView.SetImageBitmap(_imageArray[0]);
            imageView.Draw(page.Canvas);
            document.FinishPage(page);
            var outPut = new MemoryStream();
            try
            {
                document.WriteTo(outPut);
                document.Close();
                outPut.Close();
            }
            catch (Exception)
            {
            }
            return outPut.ToArray();
        }
