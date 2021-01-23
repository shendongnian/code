    private void highlightPDFAnnotation(string outputFile, string highLightFile, int pageno, string[] splitText)
    {
        PdfReader reader = new PdfReader(outputFile);
        iTextSharp.text.pdf.PdfContentByte canvas;
        using (FileStream fs = new FileStream(highLightFile, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            using (PdfStamper stamper = new PdfStamper(reader, fs))
            {
                myLocationTextExtractionStrategy strategy = new myLocationTextExtractionStrategy();
                strategy.UndercontentHorizontalScaling = 100;
                string currentText = PdfTextExtractor.GetTextFromPage(reader, pageno, strategy);
                for (int i = 0; i < splitText.Length; i++)
                {
                    List<iTextSharp.text.Rectangle> MatchesFound = strategy.GetTextLocations(splitText[i].Trim(), StringComparison.CurrentCultureIgnoreCase);
                    foreach (Rectangle rect in MatchesFound)
                    {
                        float[] quad = { rect.Left - 3.0f, rect.Bottom, rect.Right, rect.Bottom, rect.Left - 3.0f, rect.Top + 1.0f, rect.Right, rect.Top + 1.0f };
                        //Create our hightlight
                        PdfAnnotation highlight = PdfAnnotation.CreateMarkup(stamper.Writer, rect, null, PdfAnnotation.MARKUP_HIGHLIGHT, quad);
                        //Set the color
                        highlight.Color = BaseColor.YELLOW;
                        PdfAppearance appearance = PdfAppearance.CreateAppearance(stamper.Writer, rect.Width, rect.Height);
                        PdfGState state = new PdfGState();
                        state.BlendMode = new PdfName("Multiply");
                        appearance.SetGState(state);
                        appearance.Rectangle(0, 0, rect.Width, rect.Height);
                        appearance.SetColorFill(BaseColor.YELLOW);
                        appearance.Fill();
                        highlight.SetAppearance(PdfAnnotation.APPEARANCE_NORMAL, appearance);
                        //Add the annotation
                        stamper.AddAnnotation(highlight, pageno);
                    }
                }
            }
        }
        reader.Close();
    }
