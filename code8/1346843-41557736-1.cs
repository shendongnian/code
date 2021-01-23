    PdfPages pageCollection = pdfDoc.Pages;
            for (int i = 0; i < pageCollection.Count; i++)
            {
                if (pageCollection[i].Orientation.ToString().Equals("Landscape"))
                {
                    if (pageCollection[i].Rotate == 90)
                    {
                        pageCollection[i].Orientation = PageOrientation.Portrait;
                    }
                }
            }
        
